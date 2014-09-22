using System;
using System.ComponentModel.DataAnnotations;

namespace AtmDb.Model
{
    public class TransactionHistory
    {
        public TransactionHistory()
        {
            this.TransactionDate = DateTime.Now;
        }

        public int ID { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string CardNumber { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public MoneyTransactionType Action { get; set; }
    }
}
