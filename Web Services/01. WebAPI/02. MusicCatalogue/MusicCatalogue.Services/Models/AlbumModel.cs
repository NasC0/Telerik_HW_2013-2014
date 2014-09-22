using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using MusicCatalogue.Model;

namespace MusicCatalogue.Services.Models
{
    public class AlbumModel
    {
        public static Expression<Func<Album, AlbumModel>> FromAlbum
        {
            get
            {
                return album => new AlbumModel
                {
                    AlbumID = album.AlbumID,
                    Name = album.Name,
                    Producer = album.Producer,
                    Year = album.Year
                };
            }
        }

        public int AlbumID { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Producer { get; set; }
    }
}