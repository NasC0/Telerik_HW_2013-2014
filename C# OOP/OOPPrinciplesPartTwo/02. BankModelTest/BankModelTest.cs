/* Task 2. A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts. 
 * Customers could be individuals or companies. All accounts have customer, balance and interest rate (monthly based). 
 * Deposit accounts are allowed to deposit and with draw money. Loan and mortgage accounts can only deposit money. 
 * All accounts can calculate their interest amount for a given period (in months).
 * In the common case its is calculated as follows: number_of_months * interest_rate.
 * Loan accounts have no interest for the first 3 months if are held by individuals and for the first 2 months if are held by a company.
 * Deposit accounts have no interest if their balance is positive and less than 1000.
 * Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the first 6 months for individuals.
 * Your task is to write a program to model the bank system by classes and interfaces. You should identify the classes, interfaces, base classes 
 * and abstract actions and implement the calculation of the interest functionality through overridden methods. */

namespace _02.BankModelTest
{
    using System;
    using System.Collections.Generic;
    using BankModel;

    class BankModelTest
    {
        static void Main()
        {
            Individual gosho = new Individual("Gosho");
            Company goshoCorp = new Company("GoshoCorp");

            List<IDepositable> depositAccounts = new List<IDepositable>()
            {
                new LoanAccount(gosho, 1500, 5.2m),
                new LoanAccount(goshoCorp, 15000.120m, 15.3m),
                new MortgageAccount(gosho, 1000, 6.2m),
                new MortgageAccount(goshoCorp, 10000, 11.5m)
            };

            foreach (var account in depositAccounts)
            {
                Console.WriteLine((account as Account).Balance);
                account.Deposit(125.50m);
            }

            Console.WriteLine();

            foreach (var account in depositAccounts)
            {
                Console.WriteLine((account as Account).Balance);

                Console.WriteLine((account as Account).CalculateInterestRate(15));
            }

            Console.WriteLine();

            List<IWithdrawable> withdrawAccounts = new List<IWithdrawable>()
            {
                new DepositAccount(gosho, 1000, 4.5m),
                new DepositAccount(goshoCorp, 20000, 1.5m)
            };

            foreach (var account in withdrawAccounts)
            {
                account.Withdraw(1000);
                Console.WriteLine((account as Account).Balance);
            }

            Console.WriteLine();

            foreach (var account in withdrawAccounts)
            {
                (account as IDepositable).Deposit(500);
                Console.WriteLine((account as Account).Balance);
            }

            Console.WriteLine();

            foreach (var account in withdrawAccounts)
            {
                Console.WriteLine((account as Account).CalculateInterestRate(15));
            }
        }
    }
}
