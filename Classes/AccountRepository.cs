using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class AccountRepository
    {
        private List<IAccount> _accountsDirectory = new List<IAccount>();

        public void AddAccountToDirectory(IAccount account)
        {
            _accountsDirectory.Add(account);
        }

        public bool TransferBetweenAccounts(int accountIdFrom, int accountIdTo, decimal amount)
        {
            IAccount accountFrom = GetAccountById(accountIdFrom);
            IAccount accountTo = GetAccountById(accountIdTo);

            if (accountFrom.Withdraw(amount) && accountTo.Deposit(amount))
            {
                return true;
            }
            return false;
        }

        public List<IAccount> GetAllAccounts()
        {
            return _accountsDirectory;
        }

        //Helper method to identify one specific account in the directy given the Id
        public IAccount GetAccountById(int accountId)
        {
            foreach (var account in _accountsDirectory)
            {
                if (account.Id == accountId)
                {
                    return account;
                }
            }
            return null;
        }

        //Get the list of accounts at a particular bank
        public List<IAccount> GetAccountsByBankId(int bankId)
        {
            List<IAccount> bankAccounts = new List<IAccount>();
            foreach (var account in _accountsDirectory)
            {
                if (account.BankId == bankId)
                {
                    bankAccounts.Add(account);
                }
            }
            return bankAccounts;
        }
    }
}
