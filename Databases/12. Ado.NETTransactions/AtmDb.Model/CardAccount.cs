using System.ComponentModel.DataAnnotations;

namespace AtmDb.Model
{
    public class CardAccount
    {
        public int ID { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string CardNumber { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        public string CardPin { get; set; }

        public decimal CardCash { get; set; }
    }
}
