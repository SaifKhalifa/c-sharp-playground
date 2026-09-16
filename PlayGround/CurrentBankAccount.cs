using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround.BankAccounts
{
    public class CurrentBankAccount : BankAccount
    {
        public CurrentBankAccount(string holderName, double startingBalance = 0) : base(holderName, startingBalance)
        {
            Console.WriteLine("*INFO*: New Current Bank Account is created under name: " + holderName);
        }

        public override void Withdraw(double amount)
        {
            double interest = amount * (1.5 / 100);
            base.Withdraw(amount + interest);
        }
    }

    public class SavingsBankAccount : BankAccount
    {
        public SavingsBankAccount(string holderName, double startingBalance = 0) : base(holderName, startingBalance)
        {
            Console.WriteLine("*INFO*: New Savings Bank Account is created under name: " + holderName);
        }
    }
}
