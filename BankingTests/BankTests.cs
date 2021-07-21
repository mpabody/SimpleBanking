using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BankingTests
{
    [TestClass]
    public class BankTests
    {
        private BankRepository _bankRepository = new BankRepository();
        [TestMethod]
        public void AddBankToDirectoryShouldReturnCorrectCount()
        {
            //Arrange
            Bank bank = new Bank("Chase", "111 Main St", "3171234567");
            int startingCount = _bankRepository.GetAllBanks().Count;

            //Act
            _bankRepository.AddBankToDirectory(bank);

            //Assert
            Assert.IsTrue(startingCount < _bankRepository.GetAllBanks().Count);
        }

        [TestMethod]
        public void GetAllBanksShouldReturnCorrectCollection()
        {
            //Arrange
            Bank bank = new Bank("PNC", "111 South St", "8129876543");
            _bankRepository.AddBankToDirectory(bank);

            //Act
            List<Bank> allClients = _bankRepository.GetAllBanks();

            //Assert
            Assert.IsTrue(allClients.Contains(bank));
        }
    }
}
