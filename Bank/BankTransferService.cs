namespace Bank;

/// <summary>
/// Выполняет переводы денег между банковскими счетами.
/// </summary>
public static class BankTransferService
{
    /// <summary>
    /// Переводит деньги с одного счёта на другой.
    /// </summary>
    /// <param name="from">Счёт, с которого переводят деньги.</param>
    /// <param name="to">Счёт, на который переводят деньги.</param>
    /// <param name="amount">Сумма перевода.</param>
    public static void Transfer(
        BankAccount from,
        BankAccount to,
        decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(amount),
                "Сумма перевода должна быть положительной.");
        }

        if (from == to)
        {
            throw new ArgumentException(
                "Нельзя переводить деньги на тот же счёт.");
        }

        from.MakeWithdrawal(
            amount,
            DateTime.UtcNow,
            "Transfer to account " + to.Number);

        try
        {
            to.MakeDeposit(
                amount,
                DateTime.UtcNow,
                "Transfer from account " + from.Number);
        }
        catch
        {
            from.MakeDeposit(
                amount,
                DateTime.UtcNow,
                "Refund of failed transfer");

            throw;
        }
    }
}