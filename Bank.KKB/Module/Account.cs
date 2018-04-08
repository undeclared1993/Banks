using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.KKB.Module
{
    public class Account
    {
        public Account()
        {

        }
        public DateTime CreatDate { get; set; }
        public DateTime CloseDate { get; set; }
        public Decimal Score { get; set; } = 0M;
        public String AccNumb { get; set; }


    }
}
