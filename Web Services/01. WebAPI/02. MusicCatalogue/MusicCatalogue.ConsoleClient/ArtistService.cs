using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using MusicCatalogue.Model.ServiceModels;
using Newtonsoft.Json;

namespace MusicCatalogue.ConsoleClient
{
    public class ArtistService : ServiceProcessor<ArtistModel>, IServiceProcessor<ArtistModel>
    {
        private string artistServiceLocation;

        public ArtistService(HttpClient webClient, string apiLocation, string artistServiceLocation)
            : base(webClient, apiLocation)
        {
            this.artistServiceLocation = this.ApiLocation + '/' + artistServiceLocation;
        }

        public string ArtistServiceLocation
        {
            get
            {
                return this.artistServiceLocation;
            }
        }

        public IEnumerable<ArtistModel> GetAll()
        {
            string url = string.Format("{0}/Artists", this.ArtistServiceLocation);
            return base.GetAll(url);
        }

        public ArtistModel GetByID(int artistID)
        {
            string url = string.Format("{0}/Artists/{1}", this.ArtistServiceLocation, artistID);
            return base.GetByID(url);
        }

        public void Add(ArtistModel entry)
        {
            string url = string.Format("{0}/AddArtist", this.ArtistServiceLocation);
            base.Add(url, entry);
        }

        public void Modify(int artistID, ArtistModel entry)
        {
            string url = string.Format("{0}/ModifyArtist/{1}", this.ArtistServiceLocation, artistID);
            base.Modify(url, entry);
        }

        public ArtistModel Delete(int artistID)
        {
            string url = string.Format("{0}/DeleteArtist/{1}", this.ArtistServiceLocation, artistID);
            return base.Delete(url);
        }

        public IEnumerable<SongModel> GetSongs(int artistID)
        {
            string url = string.Format("{0}/GetSongs/{1}", this.ArtistServiceLocation, artistID);
            return this.Get<IEnumerable<SongModel>>(url);
        }

        public IEnumerable<AlbumModel> GetAlbums(int artistID)
        {
            string url = string.Format("{0}/GetAlbums/{1}", this.ArtistServiceLocation, artistID);
            return this.Get<IEnumerable<AlbumModel>>(url);
        }

        public void AddSong(int artistID, int songID)
        {
            string url = string.Format("{0}/AddSong/{1}?songID={2}", this.ArtistServiceLocation, artistID, songID);
            this.AddEntry(url);
        }

        public void AddAlbum(int artistID, int albumID)
        {
            string url = string.Format("{0}/AddAlbum/{1}?albumID={2}", this.ArtistServiceLocation, artistID, albumID);
            this.AddEntry(url);
        }
    }
}
