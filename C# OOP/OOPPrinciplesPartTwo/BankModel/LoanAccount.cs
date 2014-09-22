/* Loan and mortgage accounts can only deposit money.
 * Loan accounts have no interest for the first 3 months if are held by individuals and for the first 2 months if are held by a company. */

namespace BankModel
{
    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(Customer client, decimal balance, decimal interestRate)
            :base(client, balance, interestRate)
        {
            
        }

        public override decimal CalculateInterestRate(double numberOfMonths)
        {
            if (this.Client is Customer)
            {
                if (numberOfMonths >= 3)
                {
                    numberOfMonths -= 3;
                }
                else
                {
                    numberOfMonths = 0;
                }
            }
            else if(this.Client is Company)
            {
                if (numberOfMonths >= 2)
                {
                    numberOfMonths -= 2;
                }
                else
                {
                    numberOfMonths = 0;
                }
            }

            return base.CalculateInterestRate(numberOfMonths);
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }
    }
}
