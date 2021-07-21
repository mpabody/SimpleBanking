using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BankingTests
{
    [TestClass]
    public class AccountTests
    {
        private AccountRepository _accountRepository;
        private CheckingAccount _chkAccount;
        private CorporateInvestmentAccount _corpInvAcct;
        private IndividualInvestmentAccount _indInvAcct;

        [TestInitialize]
        public void Arrrange()
        {
            _accountRepository = new AccountRepository();
            _chkAccount = new CheckingAccount(1, 1, 1);
            _corpInvAcct = new CorporateInvestmentAccount(2, 2, 2);
            _indInvAcct = new IndividualInvestmentAccount(3, 1, 3);

            _accountRepository.AddAccountToDirectory(_chkAccount);
            _accountRepository.AddAccountToDirectory(_corpInvAcct);
            _accountRepository.AddAccountToDirectory(_indInvAcct);

            _chkAccount.Deposit(2000);
            _corpInvAcct.Deposit(2000);
            _indInvAcct.Deposit(2000);
        }

        [TestMethod]
        public void AddAccountToDirectory_ShouldReturnCorrectCount()
        {
            int startingCount = _accountRepository.GetAllAccounts().Count;

            _accountRepository.AddAccountToDirectory(new CorporateInvestmentAccount(3, 3, 3));

            Assert.IsTrue(startingCount < _accountRepository.GetAllAccounts().Count);
        }

        [DataTestMethod]
        [DataRow(1, 2, 100, true)]
        [DataRow(2, 3, 0, false)]
        [DataRow(3, 1, 1000, true)]
        [DataRow(1, 3, 3000, false)]
        [DataRow(2, 1, 600, true)]
        [DataRow(3, 2, -100, false)]
        public void TransferMoney_ShouldReturnCorrectResult(int accountIdFrom, int accountIdTo, int amount, bool expectredResult)
        {
            bool result = _accountRepository.TransferBetweenAccounts(accountIdFrom, accountIdTo, Convert.ToDecimal(amount));

            Assert.AreEqual(expectredResult, result);
        }

        [TestMethod]
        public void GetAllAccounts_ShouldReturnCorrectCollection()
        {
            List<IAccount> allAccounts = _accountRepository.GetAllAccounts();

            Assert.IsTrue(allAccounts.Contains(_chkAccount));
        }

        [TestMethod]
        public void GetAccountById_ShouldReturnCorrectAccount()
        {
            var account = _accountRepository.GetAccountById(2);

            Assert.AreEqual(_corpInvAcct, account);
        }

        [TestMethod]
        public void GetAccountsByBankId_ShouldReturnCorrectAccount()
        {
            var accounts = _accountRepository.GetAccountsByBankId(1);

            Assert.IsTrue(accounts.Contains(_chkAccount));
        }

        [DataTestMethod]
        [DataRow(2001, false)]
        [DataRow(2000, true)]
        [DataRow(0, false)]
        [DataRow(100, true)]
        public void WithdrawFromCheckingAccount_ShouldReturnCorrectResult(int amount, bool expectedResult)
        {
            bool result = _chkAccount.Withdraw(amount);

            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(2001, false)]
        [DataRow(2000, true)]
        [DataRow(0, false)]
        [DataRow(100, true)]
        public void WithdrawFromCorporateInvestmentAccount_ShouldReturnCorrectResult(int amount, bool expectedResult)
        {
            bool result = _corpInvAcct.Withdraw(amount);

            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(2001, false)]
        [DataRow(1001, false)]
        [DataRow(1000, true)]
        [DataRow(0, false)]
        [DataRow(100, true)]
        public void WithdrawFromIndividualInvestmentAccount_ShouldReturnCorrectResult(int amount, bool expectedResult)
        {
            bool result = _indInvAcct.Withdraw(amount);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow(100, 2100, true)]
        [DataRow(0, 2000, false)]
        [DataRow(-500, 2000, false)]
        public void DepositToCheckingAccount_ShouldReturnCorrectResult(int amount, int newBalance, bool expectedResult)
        {
            bool result = _chkAccount.Deposit(amount);

            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(_chkAccount.Balance, newBalance);
        }

        [TestMethod]
        [DataRow(100, 2100, true)]
        [DataRow(0, 2000, false)]
        [DataRow(-500, 2000, false)]
        public void DepositToCorporateInvestmentAccount_ShouldReturnCorrectResult(int amount, int newBalance, bool expectedResult)
        {
            bool result = _corpInvAcct.Deposit(amount);

            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(_corpInvAcct.Balance, newBalance);
        }

        [TestMethod]
        [DataRow(100, 2100, true)]
        [DataRow(0, 2000, false)]
        [DataRow(-500, 2000, false)]
        public void DepositToIndividualInvestmentAccount_ShouldReturnCorrectResult(int amount, int newBalance, bool expectedResult)
        {
            bool result = _indInvAcct.Deposit(amount);

            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(_indInvAcct.Balance, newBalance);
        }
    }
}
