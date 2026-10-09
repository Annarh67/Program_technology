namespace Bank
{
    /// <summary>
    /// Представляет накопительный банковский счёт с начислением процентов.
    /// </summary>
    public class InterestEarningAccount : BankAccount
    {
        /// <summary>
        /// Создаёт накопительный счёт с начальным балансом.
        /// </summary>
        /// <param name="name">Имя владельца счёта.</param>
        /// <param name="initialBalance">Начальный баланс счёта.</param>
        public InterestEarningAccount(
            string name,
            decimal initialBalance)
            : base(name, initialBalance)
        {
        }

        // override позволяет в дочернем классе определить новую реализацию
        // метода PerformMonthAndTransactions

        /// <summary>
        /// Начисляет ежемесячные проценты на остаток счёта.
        /// </summary>
        public override void PerformMonthAndTransactions()
        {
            if (Balance > 500m)
            {
                decimal interest = Balance * 0.02m;
                MakeDeposit(interest, DateTime.UtcNow, "Apply month interest");
            }
        }
    }
}
