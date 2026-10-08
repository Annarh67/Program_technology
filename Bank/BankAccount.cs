namespace Bank;

public class BankAccount
{
    private readonly decimal _minimumBalance;
    static private int s_accountNuberSeed = 1000000000;
    public string Number { get; }
    public string Owner { get; private set; }
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

    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0)
    {

    }


    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {
       
        Owner = name; // this.Owner = name
        
        Number = s_accountNuberSeed.ToString();
        s_accountNuberSeed++;

        _minimumBalance = minimumBalance;
        
        if (initialBalance > 0)
            MakeDeposit(initialBalance, DateTime.UtcNow, "Initial balance");

    }
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        { 
        throw new ArgumentOutOfRangeException(nameof(amount),"Amount of deposit must be positive");
        }

        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }

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
            //так как тип возвращаемого значения - ссылочный, то
            //default = null
            return default; // == return null;
        }
        
    }

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
    public virtual void PerformMonthAndTransactions()
    {
    }
}
