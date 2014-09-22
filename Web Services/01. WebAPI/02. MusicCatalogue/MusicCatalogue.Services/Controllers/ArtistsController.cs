using System.Linq;
using System.Web.Http;
using MusicCatalogue.Data;
using MusicCatalogue.Model;
using MusicCatalogue.Model.ServiceModels;

namespace MusicCatalogue.Services.Controllers
{
    public class ArtistsController : ApiController
    {
        private const string InvalidArtistID = "Bad request - invalid artist ID.";
        private const string InvalidSongID = "Bad request - invalid song ID.";
        private const string InvalidAlbumID = "Bad request - invalid album ID.";
        private const string InvalidModel = "Bad request - invalid artist model.";

        private IMusicCatalogueData data;

        public ArtistsController()
            : this(new MusicCatalogueData())
        {
        }

        public ArtistsController(IMusicCatalogueData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult Artists()
        {
            var artists = this.data.Artists.GetAll().Select(ArtistModel.FromArtist);
            return Ok(artists);
        }

        [HttpGet]
        public IHttpActionResult Artists(int id)
        {
            var artist = this.data.Artists.Find(a => a.ArtistID == id).Select(ArtistModel.FromArtist).FirstOrDefault();
            if (artist == null)
            {
                return BadRequest(InvalidArtistID);
            }

            return Ok(artist);
        }

        [HttpPost]
        public IHttpActionResult AddArtist(ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(InvalidModel);
            }

            var newArtist = new Artist
            {
                Name = artist.Name,
                Country = artist.Country,
                DateOfBirth = artist.DateOfBirth
            };

            this.data.Artists.Add(newArtist);
            this.data.SaveChanges();
            artist.ArtistID = newArtist.ArtistID;

            return Ok(artist);
        }

        [HttpPut]
        public IHttpActionResult ModifyArtist(int id, ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(InvalidModel);
            }

            var artistToModify = this.data.Artists.Find(a => a.ArtistID == id).FirstOrDefault();
            if (artistToModify == null)
            {
                return BadRequest(InvalidArtistID);
            }

            artistToModify.Name = artist.Name;
            artistToModify.Country = artist.Country;
            artistToModify.DateOfBirth = artist.DateOfBirth;
            this.data.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteArtist(int id)
        {
            var artistToDelete = this.data.Artists.Find(a => a.ArtistID == id).FirstOrDefault();
            if (artistToDelete == null)
            {
                return BadRequest(InvalidArtistID);
            }

            this.data.Artists.Remove(artistToDelete);
            this.data.SaveChanges();

            return Ok(new ArtistModel
                {
                    ArtistID = artistToDelete.ArtistID,
                    Name = artistToDelete.Name,
                    DateOfBirth = artistToDelete.DateOfBirth,
                    Country = artistToDelete.Country
                });
        }

        [HttpGet]
        public IHttpActionResult GetSongs(int id)
        {
            var artist = this.data.Artists.Find(a => a.ArtistID == id).FirstOrDefault();
            if (artist == null)
            {
                return BadRequest(InvalidArtistID);
            }

            var songs = artist.Songs.AsQueryable().Select(SongModel.FromSong);

            return Ok(songs);
        }

        [HttpGet]
        public IHttpActionResult GetAlbums(int id)
        {
            var artist = this.data.Artists.Find(a => a.ArtistID == id).FirstOrDefault();
            if (artist == null)
            {
                return BadRequest(InvalidArtistID);
            }

            var albums = artist.Albums.AsQueryable().Select(AlbumModel.FromAlbum);

            return Ok(albums);
        }

        [HttpPut]
        public IHttpActionResult AddSong(int id, int songID)
        {
            var artist = this.data.Artists.Find(a => a.ArtistID == id).FirstOrDefault();
            if (artist == null)
            {
                return BadRequest(InvalidArtistID);
            }

            var song = this.data.Songs.Find(s => s.SongID == songID).FirstOrDefault();
            if (song == null)
            {
                return BadRequest(InvalidSongID);
            }

            artist.Songs.Add(song);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult AddAlbum(int id, int albumID)
        {
            var artist = this.data.Artists.Find(a => a.ArtistID == id).FirstOrDefault();
            if (artist == null)
            {
                return BadRequest(InvalidArtistID);
            }

            var album = this.data.Albums.Find(a => a.AlbumID == albumID).FirstOrDefault();
            if (album == null)
            {
                return BadRequest(InvalidAlbumID);
            }

            artist.Albums.Add(album);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
