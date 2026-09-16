using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround.BankAccounts
{
    public class BankAccount
    {
        protected Guid? _accountNumber;

        public string? HolderName { get; protected set; }

        public double? Balance { get; protected set; }

        public BankAccount(string holderName, double startingBalance = 0d)
        {            
            if (ValidateNewAccountCreation(holderName, startingBalance))                
            {
                _accountNumber = Guid.NewGuid();
                HolderName = holderName;
                Balance = startingBalance;
            }                
        }

        ~BankAccount() // destructor not deconstractor
        {
            // from my search, the .NET GC `Garbage Collector` will automatically collects any null or unrefernced variables or objects
            // so if we needed to delete an account, simply we assign null to everything this object has, after that the object should be also assigned to null.
            // this is step is recommended as it also clears the object fields after the obj gets collected by the GC, just in case any value is left in the memoty
            this._accountNumber = null;
            this.HolderName = null;
            this.Balance = null;

            Console.WriteLine("ACCOUNT DELETED SUCCEFULLY!");
             
        } 
        protected bool ValidateNewAccountCreation(string holderName, double startingBalance)
        {
            // Check if the holder name is empty
            if (holderName.Length <= 0 || string.IsNullOrWhiteSpace(holderName))
            {
                throw new ArgumentException("Account holder name cannot be empty!\n");
            }


            // chekc if the holder name have white spaces, and it should not exceed 1 space, accepted format `Firstname Lastname`
            int _whiteSpaceCount = 0;

            foreach (char c in holderName)
            {
                if (char.IsWhiteSpace(c))
                    _whiteSpaceCount++;
            }

            if (_whiteSpaceCount > 1)
            {
                throw new ArgumentException("Account holder name cannot contain more than 1 space!, accepted name format: `Firstname Lastname`");
            }

            // check if the string is all letters and contains 1 whitespace
            int _letterCount = 0;
            foreach (char c in holderName)
            {
                if (char.IsLetter(c))
                    _letterCount++;
            }

            if (_letterCount + _whiteSpaceCount != holderName.Length)
                throw new ArgumentException("Account holder name cannot contain any number or symbols, accepted name format: `Firstname Lastname`");
            else
            {
                return true;
            }
        }
    
        public void Deposit(double depositValue)
        {
            //TO-DO: Check the input if it contains any letter or symbol, this will be made later when asking the user for input in the main program file.

            // check if the deposit value is zero or less
            if (depositValue <= 0)
                throw new ArgumentException("The Deposit value cannot be zero `0` or less.");
            else 
            {
                Balance += depositValue;
                Console.WriteLine("*INFO*: $" + depositValue + " have been deposited successfully into your account!");
            }

        }

        public virtual void Withdraw(double amount)
        {
            // check if the withdrawl value is zero or less
            if (amount <= 0)
                throw new ArgumentException("The withdrawl value cannot be zero `0` or less.");

            else if (amount > Balance)
                throw new ArgumentOutOfRangeException("The withdrawl value is more than your balance!");

            else
            {
                Balance -= amount;
                Console.WriteLine("*INFO*: $" + amount + " have been withdrawen successfully from your account!, available balance: " + "$" + Balance);
            }
        }
    }
}