using System;
using System.Collections.Generic;
using System.Net.Http;
using MusicCatalogue.Model.ServiceModels;

namespace MusicCatalogue.ConsoleClient
{
    public class AlbumService : ServiceProcessor<AlbumModel>, IServiceProcessor<AlbumModel>
    {
        private string albumServiceLocation;

        public AlbumService(HttpClient webClient, string apiLocation, string albumServiceLocation)
            : base(webClient, apiLocation)
        {
            this.albumServiceLocation = this.ApiLocation + '/' + albumServiceLocation;
        }

        public string AlbumServiceLocation
        {
            get
            {
                return this.albumServiceLocation;
            }
        }

        public IEnumerable<AlbumModel> GetAll()
        {
            string url = string.Format("{0}/Albums", this.AlbumServiceLocation);
            return base.GetAll(url);
        }

        public AlbumModel GetByID(int albumID)
        {
            string url = string.Format("{0}/Albums/{1}", this.AlbumServiceLocation, albumID);
            return base.GetByID(url);
        }

        public void Add(AlbumModel entry)
        {
            string url = string.Format("{0}/AddAlbum", this.AlbumServiceLocation);
            base.Add(url, entry);
        }

        public void Modify(int albumID, AlbumModel entry)
        {
            string url = string.Format("{0}/ModifyAlbum/{1}", this.AlbumServiceLocation, albumID);
            base.Modify(url, entry);
        }

        public AlbumModel Delete(int albumID)
        {
            string url = string.Format("{0}/DeleteAlbum/{1}", this.AlbumServiceLocation, albumID);
            return base.Delete(url);
        }

        public IEnumerable<ArtistModel> GetArtists(int albumID)
        {
            string url = string.Format("{0}/GetArtists/{1}", this.AlbumServiceLocation, albumID);
            return base.Get<IEnumerable<ArtistModel>>(url);
        }

        public IEnumerable<SongModel> GetSongs(int albumID)
        {
            string url = string.Format("{0}/GetSongs/{1}", this.AlbumServiceLocation, albumID);
            return base.Get<IEnumerable<SongModel>>(url);
        }

        public void AddSong(int albumID, int songID)
        {
            string url = string.Format("{0}/AddSong/{1}?songID={2}", this.AlbumServiceLocation, albumID, songID);
            base.AddEntry(url);
        }

        public void AddArtist(int albumID, int artistID)
        {
            string url = string.Format("{0}/AddArtist/{1}?artistID={2}", this.AlbumServiceLocation, albumID, artistID);
            base.AddEntry(url);
        }
    }
}
