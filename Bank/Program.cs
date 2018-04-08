using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.KKB.Module;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Banks RBK = new Banks();
            Int32 SwOperatpr = 0;
            while (true)
            {
                Console.WriteLine("1 - Sigg In\n2 - Sign Up\n3 - Exite");
                Int32.TryParse(Console.ReadLine(), out SwOperatpr);
                switch (SwOperatpr)
                {
                    case 1: Service.SignUp(RBK);break;
                    case 2: Service.SignIn(RBK); break;
                    case 3: return;
                    default:
                        break;
                }

            }

        }
    }
}
