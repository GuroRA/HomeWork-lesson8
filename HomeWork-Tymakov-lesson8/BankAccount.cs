using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork_Tymakov_lesson8
{
    enum AccountType
    {
        currentAccount,
        savingAccount,
    }

    internal class BankAccount
    {
        private static uint accountIdCounter = 1;
        private readonly uint accountId;
        public decimal Balance { private get; set; }
        private readonly AccountType accountType;
        private readonly Queue<BankTransaction> AccountTransactions = new Queue<BankTransaction>();

        public BankAccount(decimal balance, AccountType accountType)
        {
            accountId = SetCurrentId();
            Balance = balance;
            this.accountType = accountType;
        }

        public BankAccount(decimal balance)
        {
            accountId = SetCurrentId();
            Balance = balance;
        }

        public BankAccount(AccountType accountType)
        {
            accountId = SetCurrentId();
            this.accountType = accountType;
        }

        public BankAccount()
        {
            accountId = SetCurrentId();
        }

        /// <summary>
        /// Вычитает из баланса вводимое число
        /// </summary>
        /// <param name="amount"></param>
        public decimal WithdrawMoney(decimal amount)
        {
            if (Balance - amount >= 0 && amount > 0)
            {
                Balance -= amount;
                AccountTransactions.Enqueue(new BankTransaction(-amount));
            }
            else
            {
                Console.WriteLine("Недостаточно средств или некорректная сумма для снятия.\n");
            }
            return Balance;
        }

        /// <summary>
        /// Позволяет переводить деньги между акаунтами
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public decimal TransferMoney(BankAccount account, decimal amount)
        {
            if (account.Balance != account.WithdrawMoney(amount))
            {
                DepositMoney(amount);
            }
            return Balance;
        }

        /// <summary>
        /// Прибавляет к балансу вводимое число
        /// </summary>
        /// <param name="amount"></param>
        public decimal DepositMoney(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                AccountTransactions.Enqueue(new BankTransaction(amount));
            }
            else
            {
                Console.WriteLine("Сумма для пополнения должна быть положительной.\n");
            }
            return Balance;
        }

        public void Dispose()
        {
            foreach (var transaction in AccountTransactions)
            {
                File.AppendAllText($"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}/Transactions.txt", $"Время транзакции: {transaction.dateTime}\nТранзакция: {transaction.amount}\n\n");
                GC.SuppressFinalize(transaction);

            }
        }

        private static uint SetCurrentId()
        {
            return accountIdCounter++;
        }
        public void GetAccountData()
        {
            Console.WriteLine($"ID: {string.Format("{0:D7}", accountId)}\nБаланс: {Balance}\nТип аккаунта: {accountType}\n");
        }
    }
}
