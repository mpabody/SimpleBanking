using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BankingTests
{
    [TestClass]
    public class ClientTests
    {
        private ClientRepository _clientRepository = new ClientRepository();
        [TestMethod]
        public void AddClientToDirectoryShouldReturnCorrectCount()
        {
            //Arrange
            Client client = new Client(1, "Michael Pabody");
            int startingCount = _clientRepository.GetAllClients().Count;

            //Act
            _clientRepository.AddClientToDirectory(client);

            //Assert
            Assert.IsTrue(startingCount < _clientRepository.GetAllClients().Count);
        }

        [TestMethod]
        public void GetAllClientsShouldReturnCorrectCollection()
        {
            //Arrange
            Client client = new Client(1, "Michael Pabody");
            _clientRepository.AddClientToDirectory(client);

            //Act
            List<Client> allClients = _clientRepository.GetAllClients();

            //Assert
            Assert.IsTrue(allClients.Contains(client));
        }
    }
}
