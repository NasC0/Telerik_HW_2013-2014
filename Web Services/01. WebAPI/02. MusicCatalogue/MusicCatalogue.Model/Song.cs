using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicCatalogue.Model
{
    public class Song
    {
        private ICollection<Artist> artists;

        public Song()
        {
            this.artists = new HashSet<Artist>();
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

        public virtual ICollection<Artist> Artists { get; set; }

        public int? AlbumID { get; set; }

        public virtual Album Album { get; set; }
    }
}
