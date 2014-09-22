using System.Linq;
using System.Web.Http;
using MusicCatalogue.Data;
using MusicCatalogue.Model;
using MusicCatalogue.Model.ServiceModels;

namespace MusicCatalogue.Services.Controllers
{
    public class SongsController : ApiController
    {
        private const string InvalidArtistID = "Bad request - invalid artist ID.";
        private const string InvalidSongID = "Bad request - invalid song ID.";
        private const string InvalidAlbumID = "Bad request - invalid album ID.";
        private const string InvalidModel = "Bad request - invalid song model.";

        private IMusicCatalogueData data;

        public SongsController()
            : this(new MusicCatalogueData())
        {
        }

        public SongsController(IMusicCatalogueData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult Songs()
        {
            var songs = this.data.Songs.GetAll().Select(SongModel.FromSong);
            return Ok(songs);
        }

        [HttpGet]
        public IHttpActionResult Songs(int id)
        {
            var songs = this.data.Songs.Find(s => s.SongID == id).Select(SongModel.FromSong).FirstOrDefault();
            if (songs == null)
            {
                return BadRequest(InvalidSongID);
            }

            return Ok(songs);
        }

        [HttpPost]
        public IHttpActionResult AddSong(SongModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(InvalidModel);
            }

            var newSong = new Song
            {
                Title = song.Title,
                Year = song.Year,
                Genre = song.Genre,
                AlbumID = song.AlbumID
            };

            this.data.Songs.Add(newSong);
            this.data.SaveChanges();
            song.SongID = newSong.SongID;

            return Ok(song);
        }

        [HttpPut]
        public IHttpActionResult ModifySong(int id, SongModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(InvalidModel);
            }

            var songToModify = this.data.Songs.Find(s => s.SongID == id).FirstOrDefault();
            if (songToModify == null)
            {
                return BadRequest(InvalidSongID);
            }

            songToModify.Title = song.Title;
            songToModify.Year = song.Year;
            songToModify.Genre = song.Genre;
            songToModify.AlbumID = song.AlbumID;

            this.data.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteSong(int id)
        {
            var songToDelete = this.data.Songs.Find(s => s.SongID == id).FirstOrDefault();
            if (songToDelete == null)
            {
                return BadRequest(InvalidSongID);
            }

            this.data.Songs.Remove(songToDelete);
            this.data.SaveChanges();

            return Ok(new SongModel
                {
                    SongID = songToDelete.SongID,
                    Title = songToDelete.Title,
                    Year = songToDelete.Year,
                    Genre = songToDelete.Genre,
                    AlbumID = songToDelete.AlbumID
                });
        }

        [HttpGet]
        public IHttpActionResult GetArtists(int id)
        {
            var song = this.data.Songs.Find(s => s.SongID == id).FirstOrDefault();
            if (song == null)
            {
                return BadRequest(InvalidSongID);
            }

            var artists = song.Artists.AsQueryable().Select(ArtistModel.FromArtist);

            return Ok(artists);
        }

        [HttpGet]
        public IHttpActionResult GetAlbum(int id)
        {
            var song = this.data.Songs.Find(s => s.SongID == id).FirstOrDefault();
            if (song == null)
            {
                return BadRequest(InvalidSongID);
            }

            var songAlbum = song.Album;
            var album = new AlbumModel()
            {
                AlbumID = songAlbum.AlbumID,
                Name = songAlbum.Name,
                Producer = songAlbum.Producer,
                Year = songAlbum.Year
            };

            return Ok(album);
        }

        [HttpPut]
        public IHttpActionResult AddArtist(int id, int artistID)
        {
            var song = this.data.Songs.Find(s => s.SongID == id).FirstOrDefault();
            if (song == null)
            {
                return BadRequest(InvalidSongID);
            }

            var artist = this.data.Artists.Find(a => a.ArtistID == artistID).FirstOrDefault();
            if (artist == null)
            {
                return BadRequest(InvalidArtistID);
            }

            song.Artists.Add(artist);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
