using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.KKB.Module
{
    public class Banks
    {
        public Banks()
        {
            Clients = new List<Client>();
        }
        public String Description { get; set; }
        public String BankName { get; set; }

        public List<Client> Clients;

    }
}
