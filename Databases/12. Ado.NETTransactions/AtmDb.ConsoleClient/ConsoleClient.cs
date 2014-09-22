using System;
using System.Data;
using System.Linq;

using AtmDb.Data;
using AtmDb.Model;

namespace AtmDb.ConsoleClient
{
    public class ConsoleClient
    {
        public static IAtmDbData atmData = new AtmDbData();

        public static void RetrieveMoneyFromAccount(CardAccount account, decimal amount)
        {
            using (var transaction = atmData.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                try
                {
                    var checkAccount = atmData.CardAccounts.Find(x => x.ID == account.ID).FirstOrDefault();
                    if (checkAccount == null)
                    {
                        throw new ArgumentException("No such account found.");
                    }

                    if (checkAccount.CardNumber != account.CardNumber || checkAccount.CardPin != account.CardPin)
                    {
                        throw new ArgumentException("Invalid card number or pin.");
                    }

                    if (checkAccount.CardCash <= amount)
                    {
                        throw new ArgumentException("Insufficient funds.");
                    }

                    checkAccount.CardCash -= amount;
                    atmData.SaveChanges();
                    transaction.Commit();
                    Console.WriteLine("Transaction successfull.");
                    UpdateTransactionLog(account, amount, MoneyTransactionType.Withdraw);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Transaction failed: {0}", ex.Message);
                }
            }
        }

        private static void UpdateTransactionLog(CardAccount account, decimal amount, MoneyTransactionType transactionType)
        {
            using (var transaction = atmData.BeginTransaction())
            {
                try
                {
                    var currentTransactionLog = new TransactionHistory()
                    {
                        CardNumber = account.CardNumber,
                        Amount = amount,
                        Action = transactionType
                    };

                    atmData.TransactionHistory.Add(currentTransactionLog);
                    atmData.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Failed to add entry to transaction log: {0}", ex.Message);
                }
            }
        }

        public static void Main()
        {
            //var firstAccountToModify = atmData.CardAccounts.GetAll().FirstOrDefault();
            //RetrieveMoneyFromAccount(firstAccountToModify, 50034m);

            //var secondAccountToModify = new CardAccount()
            //{
            //    ID = 10000001,
            //    CardNumber = firstAccountToModify.CardNumber,
            //    CardPin = firstAccountToModify.CardPin,
            //    CardCash = firstAccountToModify.CardCash
            //};
            //RetrieveMoneyFromAccount(secondAccountToModify, 100m);

            //var thirdAccountToModify = new CardAccount()
            //{
            //    ID = firstAccountToModify.ID,
            //    CardNumber = "asdfqwerzx",
            //    CardPin = firstAccountToModify.CardPin,
            //    CardCash = firstAccountToModify.CardCash
            //};
            //RetrieveMoneyFromAccount(thirdAccountToModify, 1000m);

            //var fourthAccountToModify = new CardAccount()
            //{
            //    ID = firstAccountToModify.ID,
            //    CardNumber = firstAccountToModify.CardNumber,
            //    CardPin = "asdf",
            //    CardCash = firstAccountToModify.CardCash
            //};
            //RetrieveMoneyFromAccount(fourthAccountToModify, 100m);


            //firstAccountToModify.CardCash = 50m;
            //RetrieveMoneyFromAccount(firstAccountToModify, 100m);

            //var evenRecordsInCollection = atmData.CardAccounts.GetAll().Where(account => account.ID % 2 == 0).ToList();

            //foreach (var account in evenRecordsInCollection)
            //{
            //    RetrieveMoneyFromAccount(account, 50m);
            //}

            for (int i = 0; i < 10; i++)
            {
                var cardAccount = new CardAccount()
                {
                    CardNumber = "123456789" + i
                };

                atmData.CardAccounts.Add(cardAccount);
            }
        }
    }
}
