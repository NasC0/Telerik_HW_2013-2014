using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsDb.Model
{
    public class City
    {
        private ICollection<Dealer> dealers;

        public City()
        {
            this.dealers = new HashSet<Dealer>();
        }

        public int CityID { get; set; }

        [Required]
        [MaxLength(10)]
        [Index(IsUnique=true)]
        public string Name { get; set; }

        public virtual ICollection<Dealer> Dealers
        {
            get
            {
                return this.dealers;
            }

            set
            {
                this.dealers = value;
            }
        }
    }
}
