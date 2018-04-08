using Bank.KKB.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bank
{
    public class Service
    {
        public Service()
        {

        }

        private static List<String> IIN = new List<String>();
        private static Random Rand = new Random();
        public static void SignUp(Banks Bank)
        {

            Client NewClient = new Client();
            String Ancillaryfield = String.Empty;
            Int32 SwOperator = 0;
            Boolean RegisterLogic = true;
            while (RegisterLogic)
            {
                while (true)
                {
                    Console.Clear();
                    Console.Write("Enter your IIN.Lenth == 12! : ");
                    Ancillaryfield = Console.ReadLine();
                    if (Ancillaryfield.Length != 12)
                    {
                        Console.WriteLine("N_Corr IIN, Please enter the correct IIN");
                        Console.WriteLine(" 1 - Refilling\n 2 - Back to main menu");
                        Int32.TryParse(Console.ReadLine(), out SwOperator);
                        Console.Clear();
                        switch (SwOperator)
                        {
                            case 1: continue;
                            case 2: return;
                            default:
                                break;
                        }
                    }
                    break;
                }
                NewClient.IIN = Ancillaryfield;
                Ancillaryfield = String.Empty;
                Console.Write("Enter fisrtName : ");
                NewClient.FName = Console.ReadLine();
                Console.Write("Enter lastName : ");
                NewClient.LName = Console.ReadLine();
                Console.Write("Enter your phone number : ");
                NewClient.PhoneNumber = Console.ReadLine();
                Console.Write("Enter your email : ");
                NewClient.Email = Console.ReadLine();
                while (true)
                {
                    Console.Write("Create a username : ");
                    Ancillaryfield = Console.ReadLine();
                    if (IIN.Where(f1 => f1 == Ancillaryfield).Count() > 0)
                        Console.Write("Current login is used, please select another");
                    else
                    {
                        NewClient.Log = Ancillaryfield;
                        break;
                    }

                }
                Console.Write("Create a password : ");
                NewClient.Pass = Console.ReadLine();
                NewClient.DOB = DateTime.Now;
                Console.WriteLine("Date of registration : " + NewClient.DOB);
                Console.WriteLine("\n1 - Sign Up\n2 - Fill in a blank\n3 - Return to main menu");
                Int32.TryParse(Console.ReadLine(), out SwOperator);
                Console.Clear();
                switch (SwOperator)
                {
                    case 1:
                        RegisterLogic = false;
                        break;
                    case 2: continue;
                    case 3: return;
                }
            }

            Bank.Clients.Add(NewClient);
        }
        public static void SignIn(Banks Bank)
        {
            Console.Clear();
            String Login = String.Empty;
            String Password = String.Empty;
            Int32 SwOperator = 0;
            while (true)
            {
                Console.WriteLine("Enter Login");
                Login = Console.ReadLine();
                Console.WriteLine("Enter Password");
                Password = Console.ReadLine();
                if (Bank.Clients.Where(f1 => f1.Log == Login).Count() <= 0)
                {
                    Console.WriteLine("Was entered not a valid login");
                    Console.WriteLine("1 - Retry\n2 - Back to main menu");
                    Int32.TryParse(Console.ReadLine(), out SwOperator);
                    Console.Clear();
                    switch (SwOperator)
                    {
                        case 1:
                            continue;
                        case 2:
                            return;
                        default:
                            break;
                    }
                }
                else if (Bank.Clients.Where(f1 => f1.Log == Login).Where(f2 => f2.Pass != Password).Where(f3 => f3.isBlocked != true).Count() > 0)
                {
                    Console.WriteLine("Password Not valid !");

                    foreach (var item in Bank.Clients)
                    {
                        if (item.Log == Login && item.Pass != Password)
                        {
                            item.WRONGENTER += 1;
                            continue;
                        }

                    }
                    Console.WriteLine("1 - Retry\n2 - Back to main menu");
                    Int32.TryParse(Console.ReadLine(), out SwOperator);
                    Console.Clear();
                    switch (SwOperator)
                    {
                        case 1:
                            continue;
                        case 2:
                            return;
                        default:
                            break;
                    }
                    // Bank.Clients.Where(f1 => f1.Log == Login).Where(f2 => f2.Pass != Password).Select(s => s.WRONGENTER = s.WRONGENTER + 1);
                }
                else if (Bank.Clients.Where(f1 => f1.Log == Login).Where(f2 => f2.Pass == Password).Where(f3 => f3.isBlocked == false).Count() >= 1)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Account is Blocked!");
                    Console.WriteLine("1 - Retry\n2 - Back to main menu");
                    Int32.TryParse(Console.ReadLine(), out SwOperator);
                    Console.Clear();
                    switch (SwOperator)
                    {
                        case 1:
                            continue;
                        case 2:
                            return;
                        default:
                            break;
                    }
                }

            }

            String AccNumber = String.Empty;
            Decimal Replenishment;
            while (true)
            {
                Console.WriteLine("You are Logged in");
                Console.WriteLine(" 1 - Create Account\n 2 - Replenish an account\n 3 - Withdraw\n 4 - Back to main menu\n");
                Int32.TryParse(Console.ReadLine(), out SwOperator);
                switch (SwOperator)
                {
                    case 1:// Bank.Clients.Where(f1 => f1.Log == Login).Where(f2 => f2.Pass == Password).Where(f3 => f3.isBlocked == false).Select(s => s.Accounts.Add(Service.CreateAccounts()));
                        Console.Clear();
                        Console.WriteLine("Create Account");
                        foreach (var item in Bank.Clients)
                        {
                            if (item.Log == Login && item.Pass == Password)
                            {
                                item.Accounts.Add(Service.CreateAccounts());
                                Console.WriteLine("Congratulations!, Your new account has been created");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Replenish an account");
                        foreach (var Client in Bank.Clients)
                        {
                            foreach (var Account in Client.Accounts)
                            {
                                if (Client.Log == Login && Client.Pass == Password)
                                    Console.WriteLine(String.Format("AccountNumber : {0}\t , Score : {1} ", Account.AccNumb, Account.Score));
                            }
                        }
                        Console.WriteLine("Enter account number for account replenishment");
                        AccNumber = Console.ReadLine();
                        Console.WriteLine("Enter the desired amount to fund your account");
                        Decimal.TryParse(Console.ReadLine(), out Replenishment);
                        foreach (var Client in Bank.Clients)
                        {
                            if (Client.Log == Login && Client.Pass == Password)
                            {
                                Service.ReplenishAccount(Client, AccNumber, Replenishment);
                                break;
                            }
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Withdraw");
                        foreach (var Client in Bank.Clients)
                        {
                            foreach (var Account in Client.Accounts)
                            {
                                if (Client.Log == Login && Client.Pass == Password)
                                    Console.WriteLine(String.Format("AccountNumber : {0}\t , Score : {1} ", Account.AccNumb, Account.Score));
                            }
                        }
                        Console.WriteLine("Enter the account number for withdrawal from the account");
                        AccNumber = Console.ReadLine();
                        Console.WriteLine("Enter the desired amount to withdraw funds from the account");
                        Decimal.TryParse(Console.ReadLine(), out Replenishment);
                        foreach (var Client in Bank.Clients)
                        {
                            if (Client.Log == Login && Client.Pass == Password)
                            {
                                Service.Withdraw(Client, AccNumber, Replenishment);
                                break;
                            }
                        }
                        break;
                    case 4: Console.Clear(); return;
                    default:
                        break;
                }
            }

        }
        public static void ReplenishAccount(Client Client, String AccountIdentifier, Decimal Replenishment)
        {
            Boolean CheckUsed = false;
            Decimal CurrentScore = 0;
            foreach (var account in Client.Accounts)
            {
                if (account.AccNumb == (AccountIdentifier))
                {
                    CurrentScore = account.Score += Replenishment;
                    CheckUsed = true;
                    break;
                }
            }
            if (CheckUsed == true)
                Console.WriteLine("\n Your account by number : " + AccountIdentifier +
                                  "\n Replenished with - " + Replenishment.ToString() +
                                  "\n Current sum in the account : " + CurrentScore.ToString());
            else
                Console.WriteLine("Fail");
            Console.ReadLine();
            Console.Clear();

        }
        public static void Withdraw(Client Client, String AccountIdentifier, Decimal Replenishment)
        {
            Boolean CheckUsed = false;
            Decimal CurrentScore = 0;
            foreach (var account in Client.Accounts)
            {
                if (account.AccNumb == (AccountIdentifier))
                {
                    if (account.Score < Replenishment)
                    {
                        Console.WriteLine("There are not enough funds on the account");
                        Console.ReadLine();
                        Console.Clear();
                        return;
                    }
                    CurrentScore = account.Score -= Replenishment;
                    CheckUsed = true;
                    break;
                }
            }
            if (CheckUsed == true)
                Console.WriteLine("\n Your account by number : " + AccountIdentifier +
                                  "\n Withdrawn from account - " + Replenishment.ToString() +
                                  "\n Current sum in the account : " + CurrentScore.ToString());
            else
                Console.WriteLine("Fail");
            Console.ReadLine();
            Console.Clear();
        }
        public static Account CreateAccounts()
        {
            return
                new Account()
                {
                    AccNumb = Rand.Next(515, 51251).ToString(),
                    CloseDate = DateTime.Now.AddMonths(Rand.Next(0, 12)),
                    Score = decimal.Parse(Rand.Next(515, 51251).ToString()),
                    CreatDate = DateTime.Today
                };
        }

    }
}
