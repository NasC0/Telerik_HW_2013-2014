/* Deposit accounts are allowed to deposit and with draw money.
 * Deposit accounts have no interest if their balance is positive and less than 1000. */

namespace BankModel
{
    public class DepositAccount : Account, IDepositable, IWithdrawable
    {
        public DepositAccount(Customer client, decimal balance, decimal interestRate)
            :base(client, balance, interestRate)
        {
        }
        
        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal CalculateInterestRate(double numberOfMonths)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }
            else
            {
                return this.InterestRate * (decimal)numberOfMonths;
            }
        }
    }
}
