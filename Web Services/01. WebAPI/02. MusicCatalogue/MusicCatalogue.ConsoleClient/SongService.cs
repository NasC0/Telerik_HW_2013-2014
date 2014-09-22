using System.Collections.Generic;
using System.Net.Http;
using MusicCatalogue.Model.ServiceModels;

namespace MusicCatalogue.ConsoleClient
{
    public class SongService : ServiceProcessor<SongModel>, IServiceProcessor<SongModel>
    {
        private string songServiceLocation;

        public SongService(HttpClient webClient, string apiLocation, string artistServiceLocation)
            : base(webClient, apiLocation)
        {
            this.songServiceLocation = this.ApiLocation + '/' + artistServiceLocation;
        }

        public string SongServiceLocation
        {
            get
            {
                return this.songServiceLocation;
            }
        }

        public IEnumerable<SongModel> GetAll()
        {
            string url = string.Format("{0}/Songs", this.SongServiceLocation);
            return base.GetAll(url);
        }

        public SongModel GetByID(int songID)
        {
            string url = string.Format("{0}/Songs/{1}", this.SongServiceLocation, songID);
            return base.GetByID(url);
        }

        public void Add(SongModel entry)
        {
            string url = string.Format("{0}/AddSong", this.SongServiceLocation);
            base.Add(url, entry);
        }

        public void Modify(int songID, SongModel entry)
        {
            string url = string.Format("{0}/ModifySong/{1}", this.SongServiceLocation, songID);
            base.Modify(url, entry);
        }

        public SongModel Delete(int songID)
        {
            string url = string.Format("{0}/DeleteSong/{1}", this.SongServiceLocation, songID);
            return base.Delete(url);
        }

        public IEnumerable<ArtistModel> GetArtists(int songID)
        {
            string url = string.Format("{0}/GetArtists/{1}", this.SongServiceLocation, songID);
            return base.Get<IEnumerable<ArtistModel>>(url);
        }

        public AlbumModel GetAlbum(int songID)
        {
            string url = string.Format("{0}/GetAlbum/{1}", this.SongServiceLocation, songID);
            return base.Get<AlbumModel>(url);
        }

        public void AddArtist(int songID, int artistID)
        {
            string url = string.Format("{0}/AddArtist/{1}?artistID={2}", this.SongServiceLocation, songID, artistID);
            base.AddEntry(url);
        }
    }
}
