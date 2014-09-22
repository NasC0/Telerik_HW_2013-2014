using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MusicCatalogue.Model;

namespace MusicCatalogue.Services.Models
{
    public class SongModel
    {
        public static Expression<Func<Song, SongModel>> FromSong
        {
            get
            {
                return song => new SongModel
                {
                    SongID = song.SongID,
                    Title = song.Title,
                    Year = song.Year,
                    Genre = song.Genre,
                    AlbumID = song.AlbumID
                };
            }
        }

        public int SongID { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(40)]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Genre { get; set; }

        public int? AlbumID { get; set; }
    }
}