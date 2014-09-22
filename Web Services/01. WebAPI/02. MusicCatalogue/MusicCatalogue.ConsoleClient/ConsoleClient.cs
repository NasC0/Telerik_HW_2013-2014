using System;
using System.Net.Http;
using System.Net.Http.Headers;
using MusicCatalogue.Model.ServiceModels;

namespace MusicCatalogue.ConsoleClient
{
    public class ConsoleClient
    {
        private const string BaseUrl = "http://localhost:36926/api";

        public static void Main()
        {
            var webClient = new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl)
            };
            webClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var artistService = new ArtistService(webClient, BaseUrl, "Artists");
            var artists = artistService.GetAll();
            var artist = artistService.GetByID(1);
            var songs = artistService.GetSongs(1);
            var albums = artistService.GetAlbums(1);

            var newSong = new SongModel()
            {
                Title = "I stand alone",
                Year = 2001,
                Genre = "Rock"
            };

            var songsService = new SongService(webClient, BaseUrl, "Songs");
            var songsArray = songsService.GetAll();
            var currentSong = songsService.GetByID(3);
            var artitsFromSong = songsService.GetArtists(currentSong.SongID);
            var album = songsService.GetAlbum(currentSong.SongID);
            songsService.Add(newSong);

            var albumsService = new AlbumService(webClient, BaseUrl, "Albums");
            var allAlbums = albumsService.GetAll();
            var currentAlbum = albumsService.GetByID(1);
            var artistsFromAlbum = albumsService.GetArtists(currentAlbum.AlbumID);
            var songsFromAlbum = albumsService.GetSongs(currentAlbum.AlbumID);
        }
    }
}
