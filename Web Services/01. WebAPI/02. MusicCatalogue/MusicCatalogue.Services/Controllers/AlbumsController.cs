using System.Linq;
using System.Web.Http;
using MusicCatalogue.Data;
using MusicCatalogue.Model;
using MusicCatalogue.Model.ServiceModels;

namespace MusicCatalogue.Services.Controllers
{
    public class AlbumsController : ApiController
    {
        private const string InvalidArtistID = "Bad request - invalid artist ID.";
        private const string InvalidSongID = "Bad request - invalid song ID.";
        private const string InvalidAlbumID = "Bad request - invalid album ID.";
        private const string InvalidModel = "Bad request - invalid song model.";

        private IMusicCatalogueData data;

        public AlbumsController()
            : this(new MusicCatalogueData())
        {
        }

        public AlbumsController(IMusicCatalogueData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult Albums()
        {
            var albums = this.data.Albums.GetAll().Select(AlbumModel.FromAlbum);
            return Ok(albums);
        }

        [HttpGet]
        public IHttpActionResult Albums(int id)
        {
            var albums = this.data.Albums.Find(a => a.AlbumID == id).Select(AlbumModel.FromAlbum).FirstOrDefault();
            if (albums == null)
            {
                return BadRequest(InvalidAlbumID);
            }

            return Ok(albums);
        }

        [HttpPost]
        public IHttpActionResult AddAlbum(AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(InvalidModel);
            }

            var newAlbum = new Album
            {
                Name = album.Name,
                Year = album.Year,
                Producer = album.Producer,
            };

            this.data.Albums.Add(newAlbum);
            this.data.SaveChanges();
            album.AlbumID = newAlbum.AlbumID;

            var uri = Url.Link("DefaultApi", new { id = album.AlbumID });
            return Created(uri, album);
        }

        [HttpPut]
        public IHttpActionResult ModifyAlbum(int id, AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(InvalidModel);
            }

            var albumToModify = this.data.Albums.Find(a => a.AlbumID == id).FirstOrDefault();
            if (albumToModify == null)
            {
                return BadRequest(InvalidAlbumID);
            }

            albumToModify.Name = album.Name;
            albumToModify.Year = album.Year;
            albumToModify.Producer = album.Producer;
            this.data.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAlbum(int id)
        {
            var albumToDelete = this.data.Albums.Find(a => a.AlbumID == id).FirstOrDefault();
            if (albumToDelete == null)
            {
                return BadRequest(InvalidAlbumID);
            }

            this.data.Albums.Remove(albumToDelete);
            this.data.SaveChanges();

            return Ok(new AlbumModel
            {
                AlbumID = albumToDelete.AlbumID,
                Name = albumToDelete.Name,
                Year = albumToDelete.Year,
                Producer = albumToDelete.Producer
            });
        }

        [HttpGet]
        public IHttpActionResult GetArtists(int id)
        {
            var album = this.data.Albums.Find(a => a.AlbumID == id).FirstOrDefault();
            if (album == null)
            {
                return BadRequest(InvalidAlbumID);
            }

            var artists = album.Artists.AsQueryable().Select(ArtistModel.FromArtist);

            return Ok(artists);
        }

        [HttpGet]
        public IHttpActionResult GetSongs(int id)
        {
            var album = this.data.Albums.Find(a => a.AlbumID == id).FirstOrDefault();
            if (album == null)
            {
                return BadRequest(InvalidAlbumID);
            }

            var songs = album.Songs.AsQueryable().Select(SongModel.FromSong);

            return Ok(songs);
        }

        [HttpPut]
        public IHttpActionResult AddSong(int id, int songID)
        {
            var album = this.data.Albums.Find(a => a.AlbumID == id).FirstOrDefault();
            if (album == null)
            {
                return BadRequest(InvalidAlbumID);
            }

            var song = this.data.Songs.Find(s => s.SongID == songID).FirstOrDefault();
            if (song == null)
            {
                return BadRequest(InvalidSongID);
            }

            album.Songs.Add(song);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult AddArtist(int id, int artistID)
        {
            var album = this.data.Albums.Find(a => a.AlbumID == id).FirstOrDefault();
            if (album == null)
            {
                return BadRequest(InvalidAlbumID);
            }

            var artist = this.data.Artists.Find(a => a.ArtistID == artistID).FirstOrDefault();
            if (artist == null)
            {
                return BadRequest(InvalidArtistID);
            }

            album.Artists.Add(artist);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
