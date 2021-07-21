    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class BankRepository
    {
        private List<Bank> _banksDirectory = new List<Bank>();

        public void AddBankToDirectory(Bank bank)
        {
            _banksDirectory.Add(bank);
        }

        public List<Bank> GetAllBanks()
        {
            return _banksDirectory;
        }
    }
}
