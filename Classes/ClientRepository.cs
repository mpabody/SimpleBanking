using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ClientRepository
    {
        private List<Client> _clientDirectory = new List<Client>();

        public void AddClientToDirectory(Client client)
        {
            _clientDirectory.Add(client);
        }

        public List<Client> GetAllClients()
        {
            return _clientDirectory;
        }
    }
}
