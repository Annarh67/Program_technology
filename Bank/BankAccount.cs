namespace Bank;

/// <summary>
/// Представляет банковский счёт с поддержкой финансовых операций.
/// </summary>
public class BankAccount
{
    private readonly decimal _minimumBalance;
    static private int s_accountNuberSeed = 1000000000;

    /// <summary>
    /// Возвращает уникальный номер банковского счёта.
    /// </summary>
    public string Number { get; }

    /// <summary>
    /// Возвращает имя владельца банковского счёта.
    /// </summary>
    public string Owner { get; private set; }

    /// <summary>
    /// Возвращает текущий баланс банковского счёта.
    /// </summary>
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
            }

            return balance;
        }
    }

    private List<Transaction> _allTransactions = new List<Transaction>();

    /// <summary>
    /// Создаёт банковский счёт с начальным балансом.
    /// </summary>
    /// <param name="name">Имя владельца счёта.</param>
    /// <param name="initialBalance">Начальный баланс счёта.</param>
    public BankAccount(string name, decimal initialBalance)
        : this(name, initialBalance, 0)
    {

    }

    /// <summary>
    /// Создаёт банковский счёт с заданным минимальным балансом.
    /// </summary>
    /// <param name="name">Имя владельца счёта.</param>
    /// <param name="initialBalance">Начальный баланс счёта.</param>
    /// <param name="minimumBalance">Минимально допустимый баланс счёта.</param>
    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {
        Owner = name; // this.Owner = name

        Number = s_accountNuberSeed.ToString();
        s_accountNuberSeed++;

        _minimumBalance = minimumBalance;

        if (initialBalance > 0)
            MakeDeposit(initialBalance, DateTime.UtcNow, "Initial balance");
    }

    /// <summary>
    /// Пополняет банковский счёт на указанную сумму.
    /// </summary>
    /// <param name="amount">Сумма пополнения.</param>
    /// <param name="date">Дата операции.</param>
    /// <param name="note">Комментарий к операции.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Возникает, если сумма меньше или равна нулю.
    /// </exception>
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }

        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }

    /// <summary>
    /// Снимает указанную сумму с банковского счёта.
    /// </summary>
    /// <param name="amount">Сумма снятия.</param>
    /// <param name="date">Дата операции.</param>
    /// <param name="note">Комментарий к операции.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Возникает, если сумма меньше или равна нулю.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Возникает, если операция превышает допустимый лимит счёта.
    /// </exception>
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

        Transaction? overdraftTransaction
            = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
        Transaction? withdrawal = new(-amount, date, note);

        _allTransactions.Add(withdrawal);
        if (overdraftTransaction is not null)
            _allTransactions.Add(overdraftTransaction);
    }

    private Transaction? CheckWithdrawalLimit(bool isOverdrawn)
    {
        if (isOverdrawn)
        {
            throw new InvalidOperationException("Not sufficient rubls for this withdrawal");
        }
        else
        {
            // default - содержит значение по умолчанию,
            // так как тип возвращаемого значения - ссылочный, то
            // default = null
            return default; // == return null;
        }
    }

    /// <summary>
    /// Формирует историю банковских операций.
    /// </summary>
    /// <returns>Строка с датами, суммами, балансами и комментариями операций.</returns>
    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");

        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t" +
                              $"{item.Amount}\t{balance}\t{item.Note}");
        }

        return report.ToString();
    }

    // Ключевое слово virtual позволяет в дочернем классе
    // предоставить другую реализацию
    // метода PerformMonthAndTransactions

    /// <summary>
    /// Выполняет ежемесячные операции банковского счёта.
    /// </summary>
    public virtual void PerformMonthAndTransactions()
    {
    }
}