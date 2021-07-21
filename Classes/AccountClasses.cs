using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IAccount
    {
        int Id { get; set; }
        decimal Balance { get; set; }
        int BankId { get; set; }
        int ClientId { get; set; }
        bool Deposit(decimal amount);
        bool Withdraw(decimal amount);
    }


    public class CheckingAccount : IAccount
    {
        public int Id { get; set; }
        public decimal Balance { get; set; } = 0;
        public int BankId { get; set; }
        public int ClientId { get; set; }

        public CheckingAccount(int accountId, int bankId, int clientId)
        {
            Id = accountId;
            BankId = bankId;
            ClientId = clientId;
        }

        public bool Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                return true;
            }
            return false;
        }

        public bool Withdraw(decimal amount)
        {
            if (Balance - amount >= 0 && amount > 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }

    public class CorporateInvestmentAccount : IAccount
    {
        public int Id { get; set; }
        public decimal Balance { get; set; } = 0;
        public int BankId { get; set; }
        public int ClientId { get; set; }

        public CorporateInvestmentAccount (int accountId, int bankId, int clientId)
        {
            Id = accountId;
            BankId = bankId;
            ClientId = clientId;
        }

        public bool Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                return true;
            }
            return false;
        }

        public bool Withdraw(decimal amount)
        {
            if (Balance - amount >= 0 && amount > 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }

    public class IndividualInvestmentAccount : IAccount
    {
        public int Id { get; set; }
        public decimal Balance { get; set; } = 0;
        public int BankId { get; set; }
        public int ClientId { get; set; }

        public IndividualInvestmentAccount(int accountId, int bankId, int clientId)
        {
            Id = accountId;
            BankId = bankId;
            ClientId = clientId;
        }

        public bool Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                return true;
            }
            return false;
        }

        public bool Withdraw(decimal amount)
        {
            if (Balance - amount >= 0 && amount > 0 && amount <= 1000)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }
}
