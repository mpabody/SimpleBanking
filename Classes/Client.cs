using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }

        public Client(int id, string name)
        {
            ClientId = id;
            Name = name;
        }
    }
}
