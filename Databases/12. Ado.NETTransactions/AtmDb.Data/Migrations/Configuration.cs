namespace AtmDb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<AtmDbContext>
    {
        private const int CardNumberLength = 10;
        private const int CardPinLength = 4;
        private static Random randomGenerator = new Random();

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AtmDbContext context)
        {
            if (context.CardAccount.Count() <= 0)
            {
                StringBuilder queryBuilder = new StringBuilder();
                for (int j = 0; j < 50; j++)
                {
                    queryBuilder.AppendLine("INSERT INTO CardAccounts (CardNumber, CardPin, CardCash) VALUES ");

                    string cardNumber = GetRandomNumber(CardNumberLength);
                    string cardPin = GetRandomNumber(CardPinLength);
                    decimal balance = randomGenerator.Next(0, 1000000);

                    queryBuilder.AppendLine(string.Format("('{0}', '{1}', {2}), ", cardNumber, cardPin, balance));

                    queryBuilder.Remove(queryBuilder.Length - 4, 2);
                    queryBuilder.Append(';');

                    context.Database.ExecuteSqlCommand(queryBuilder.ToString());
                    queryBuilder.Clear();
                }
            }
        }

        private string GetRandomNumber(int numberLength)
        {
            StringBuilder cardString = new StringBuilder();
            for (int i = 0; i < numberLength; i++)
            {
                int randomDigit = randomGenerator.Next(0, 10);
                cardString.Append(randomDigit);
            }

            return cardString.ToString();
        }
    }
}
