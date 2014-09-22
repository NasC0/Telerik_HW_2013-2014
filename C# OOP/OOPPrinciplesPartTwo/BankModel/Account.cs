/* Task 2. All accounts have customer, balance and interest rate (monthly based). 
 * All accounts can calculate their interest amount for a given period (in months). 
 * In the common case its is calculated as follows: number_of_months * interest_rate. */

namespace BankModel
{
    using System;
    public abstract class Account
    {
        public Account(Customer accountClient, decimal accountBalance, decimal accountInterestRate)
        {
            this.Client = accountClient;
            this.Balance = accountBalance;
            this.InterestRate = accountInterestRate;
        }

        public Customer Client { get; protected set; }

        public decimal Balance { get; protected set; }

        public decimal InterestRate { get; protected set; }

        public virtual decimal CalculateInterestRate(double numberOfMonths)
        {
            if (numberOfMonths < 0)
            {
                throw new ArgumentException("Number of months cannot be negative.");
            }
            return this.InterestRate * (decimal)numberOfMonths;
        }
    }
}
