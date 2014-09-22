/* Loan and mortgage accounts can only deposit money. 
 * Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the first 6 months for individuals. */

namespace BankModel
{
    public class MortgageAccount : Account, IDepositable
    {
        public MortgageAccount(Customer client, decimal balance, decimal interestRate)
            :base(client, balance, interestRate)
        {
            
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal CalculateInterestRate(double numberOfMonths)
        {
            if (this.Client is Individual)
            {
                if (numberOfMonths >= 6)
                {
                    numberOfMonths -= 6;
                }
                else
                {
                    numberOfMonths = 0;
                }
            }
            else if (this.Client is Company)
            {
                if (numberOfMonths >= 12)
                {
                    numberOfMonths -= 6;
                }
                else if (numberOfMonths > 0)
                {
                    numberOfMonths /= 2;
                }
            }

            return base.CalculateInterestRate(numberOfMonths);
        }
    }
}
