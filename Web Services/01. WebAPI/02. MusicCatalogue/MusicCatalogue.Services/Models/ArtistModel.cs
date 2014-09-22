using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using MusicCatalogue.Model;

namespace MusicCatalogue.Services.Models
{
    public class ArtistModel
    {
        public static Expression<Func<Artist, ArtistModel>> FromArtist
        {
            get
            {
                return artist => new ArtistModel
                {
                    ArtistID = artist.ArtistID,
                    Name = artist.Name,
                    Country = artist.Country,
                    DateOfBirth = artist.DateOfBirth
                };
            }
        }

        public int ArtistID { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Country { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}