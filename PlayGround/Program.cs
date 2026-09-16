using PlayGround.BankAccounts;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
namespace PlayGround
{
    internal class Program
    {
        public static BankAccount? bankAccount;

        static int GetIntInput()
        {
            int number;
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
                return number;
            }
            catch
            {
                Console.WriteLine("Invalid Option, Please Enter a Valid Value!");
                GetIntInput();
            }

            return 0;
        }

        static double GetDoubleInput()
        {
            double number;
            try
            {
                number = Convert.ToDouble(Console.ReadLine());
                return number;
            }
            catch
            {
                Console.WriteLine("Invalid Option, Please Enter a Valid Value!");
                GetDoubleInput();
            }

            return 0d;
        }

        static char GetKeyInput(bool hideChar = true)
        {
            ConsoleKeyInfo key;

            key = Console.ReadKey(hideChar);

            return key.KeyChar;            
        }
        

        static void CreateBankAccount(int accountType, string holderName, double startingBalance)
        {
            switch (accountType)
            {
                case 1:
                    {
                        bankAccount = new SavingsBankAccount(holderName, startingBalance);
                        break;
                    }
                case 2:
                    {
                        bankAccount = new CurrentBankAccount(holderName, startingBalance);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Option, Please Enter a Valid Value!");
                        Menu();
                        break;
                    }
            }
        }
        
        static void Menu()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("[1] Create New Account");
            Console.WriteLine("[2] Check Account Balance");
            Console.WriteLine("[3] Deposit");
            Console.WriteLine("[4] Withdraw");
            Console.WriteLine("[9] Delete Account");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("===============================");

            char choice;

            Console.Write("Your Choice = ");
            choice = GetKeyInput(false);

            switch (choice)
            {
                case '0': //Exit Program
                    Console.WriteLine("Have a Great Day,!");
                    Environment.Exit(0);
                    break;

                case '1': // Create New Account
                    {
                        string? _name;
                        double _balance = 0;
                        int _accountType = 0;

                        Console.WriteLine("\n===============================");
                        Console.WriteLine("[1] Savings Account");
                        Console.WriteLine("[2] Current Account");
                        Console.WriteLine("===============================");

                        Console.Write("Enter Account Type = ");
                        _accountType = GetIntInput();

                        Console.Write("Enter Account Holder Name = ");
                        _name = Console.ReadLine();

                        Console.Write("Enter Account Starting Balance = ");
                        _balance = GetDoubleInput();


                        Console.Clear();

                        CreateBankAccount(_accountType, _name, _balance);

                        Menu();
                        break;
                    }

                case '2': // check account balance
                    {
                        if (bankAccount == null)
                        {
                            Console.WriteLine("You didn't create a bank account!");
                            Menu();
                        }

                        Console.Clear();
                        Console.WriteLine("*INFO*: Available Account Balance for " + bankAccount.HolderName + " = $" + bankAccount.Balance);
                        Menu();
                        break;
                    }

                case '3': //deposit
                    {
                        double _depositValue = 0d;

                        Console.WriteLine("\nEnter how much would you like to deposit = ");
                        _depositValue = GetDoubleInput();

                        Console.Clear();
                        bankAccount.Deposit(_depositValue);
                        Menu();
                        break;
                    }

                case '4': //withdraw
                    {
                        double _withdrawValue = 0d;

                        Console.WriteLine("\nEnter how much would you like to withdraaw = ");
                        _withdrawValue = GetDoubleInput();

                        if (_withdrawValue == bankAccount.Balance)
                        {
                            char _key;

                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("\aWARNING, You're trying to withdraw all your account balance!, Are you sure you want to continue?");

                            Console.WriteLine("Enter `Y` to continue, or press anything to cancel the operation...");

                            _key = GetKeyInput();

                            if (_key.Equals('y') || _key.Equals('Y'))
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;

                                Console.Clear();
                                bankAccount.Withdraw(_withdrawValue);
                                Menu();
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;

                                Console.Clear();
                                Console.WriteLine("*INFO*: Withdrawl Operation Cancelled.");
                                Menu();
                            }
                        }

                        bankAccount.Withdraw(_withdrawValue);
                        break;
                    }

                case '9':
                    {
                        char _key;

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("\n\aWARNING, Are you sure you want to delete your account?");

                        Console.WriteLine("Enter `Y` to continue, or press anything to cancel the operation...");

                        _key = GetKeyInput();

                        if (_key.Equals('y') || _key.Equals('Y'))
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.Clear();
                            bankAccount = null;
                            Menu();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.Clear();
                            Console.WriteLine("*INFO*: Account Deletion Operation Cancelled.");
                            Menu();
                        }

                        break;
                    }
               
                default:
                    Console.WriteLine("Enter a valid option!");
                    break;
            }
        }


        static void Main(string[] args)
        {
            Menu();
        }
    }
}
