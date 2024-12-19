using System;

namespace HomeWork_Tymakov_lesson8
{
    class BankTransaction
    {
        public readonly DateTime dateTime = DateTime.Now;
        public readonly decimal amount;

        public BankTransaction(decimal amount)
        {
            this.amount = amount;
        }
    }
}
