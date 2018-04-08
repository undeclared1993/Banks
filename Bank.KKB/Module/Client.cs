using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bank.KKB.Module
{
    public class Client
    {
        public Client()
        {
            Accounts = new List<Account>();
        }
        #region Properties
        private String _IIN;
        public String IIN
        {
            get { return _IIN; }
            set
            {
                if (value.Length == 12)
                    _IIN = value;
                else
                    throw new Exception("N_Correct");
            }
        }
        public String Pass { get; set; }
        public String Log { get; set; }
        public String FName { get; set; }
        public String LName { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public Boolean isBlocked { get; set; } = false; 
        private int _WRONGENTER { get; set; }
        public int WRONGENTER
        {
            get { return _WRONGENTER; }
            set {
                    if (value >= 3)
                     isBlocked = true;
                    _WRONGENTER = value;
                }
        }
        #endregion

        public IList<Account> Accounts;
        public void ShowAccountInfo ()
        {
            decimal SumBalanse = 0M;
            foreach (Account item in Accounts)
            {
                Console.WriteLine(String.Format(" AccountNumber: {0}\n Create Date : {1}\n Close Date : {2}\n Score : {3}\n", item.AccNumb, item.CreatDate, item.CloseDate, item.Score));
                SumBalanse += item.Score;
            }
            Console.WriteLine("Общая сумма : " + SumBalanse);   

        }

    }
}
