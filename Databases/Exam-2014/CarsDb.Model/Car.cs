using System.ComponentModel.DataAnnotations;

namespace CarsDb.Model
{
    public class Car
    {
        public int CarID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Model { get; set; }

        [Required]
        public TransmissionType TransmissionType { get; set; }

        [Required]
        public int YearOfCreation { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ManufacturerID { get; set; }

        [Required]
        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        public virtual Dealer Dealer { get; set; }

        [Required]
        public int DealerID { get; set; }
    }
}
