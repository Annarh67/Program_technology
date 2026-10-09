using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    /// <summary>
    /// Представляет кредитный банковский счёт с установленным лимитом.
    /// </summary>
    public class LineOfCreditAccount : BankAccount
    {
        /// <summary>
        /// Создаёт кредитный счёт с заданным кредитным лимитом.
        /// </summary>
        /// <param name="name">Имя владельца счёта.</param>
        /// <param name="initialBalance">Начальный баланс счёта.</param>
        /// <param name="creditLimit">Максимально допустимая сумма задолженности.</param>
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit)
            : base(name, initialBalance, -creditLimit)
        {

        }
    }
}
