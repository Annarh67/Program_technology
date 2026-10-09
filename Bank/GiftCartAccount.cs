using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    /// <summary>
    /// Представляет подарочный счёт с ежемесячным пополнением.
    /// </summary>
    public class GiftCartAccount : BankAccount
    {
        private readonly decimal _monthlyDeposit = 0m;

        // monthlyDeposit - параметр по умолчанию (принимает 0),
        // при создании new GiftCartAccount("Yana",1000); => monthlyDeposit = 0
        // new GiftCartAccount("Yana",1000,5000); => monthlyDeposit = 5000

        /// <summary>
        /// Создаёт подарочный счёт с заданной суммой пополнения.
        /// </summary>
        /// <param name="name">Имя владельца счёта.</param>
        /// <param name="initialBalance">Начальный баланс счёта.</param>
        /// <param name="monthlyDeposit">Сумма ежемесячного пополнения, по умолчанию равная нулю.</param>
        public GiftCartAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0)
            : base(name, initialBalance)
            => _monthlyDeposit = monthlyDeposit;

        /// <summary>
        /// Выполняет ежемесячное пополнение подарочного счёта.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Возникает, если сумма ежемесячного пополнения отрицательная.
        /// </exception>
        public override void PerformMonthAndTransactions()
        {
            if (_monthlyDeposit != 0)
            {
                MakeDeposit(_monthlyDeposit, DateTime.UtcNow, "Add monthnly deposit");
            }
        }

        /// <summary>
        /// Возвращает строковое представление подарочного счёта.
        /// </summary>
        /// <returns>Строка с информацией о счёте и сумме ежемесячного пополнения.</returns>
        public override string ToString()
            => base.ToString() + $"monthly deposit: {_monthlyDeposit}";
    }
}
