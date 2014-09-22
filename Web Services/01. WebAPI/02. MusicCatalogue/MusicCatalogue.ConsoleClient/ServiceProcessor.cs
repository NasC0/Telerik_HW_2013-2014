using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace MusicCatalogue.ConsoleClient
{
    public abstract class ServiceProcessor<T>
    {
        private HttpClient serviceClient;

        public ServiceProcessor(HttpClient serviceClient, string apiLocation)
        {
            this.ServiceClient = serviceClient;
            this.ApiLocation = apiLocation;
        }

        protected HttpClient ServiceClient
        {
            get
            {
                return this.serviceClient;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Service client must be initialized.");
                }

                this.serviceClient = value;
            }
        }

        protected string ApiLocation { get; private set; }

        protected virtual IEnumerable<T> GetAll(string apiLocation)
        {
            HttpResponseMessage response = this.ServiceClient.GetAsync(apiLocation).Result;
            if (response.IsSuccessStatusCode)
            {
                var artistsJson = response.Content.ReadAsStringAsync().Result;
                var artists = JsonConvert.DeserializeObject<IEnumerable<T>>(artistsJson);
                return artists;
            }

            throw new ArgumentException("Could not fetch response");
        }

        protected virtual T GetByID(string apiLocation)
        {
            HttpResponseMessage response = this.ServiceClient.GetAsync(apiLocation).Result;
            if (response.IsSuccessStatusCode)
            {
                var artistsJson = response.Content.ReadAsStringAsync().Result;
                var artist = JsonConvert.DeserializeObject<T>(artistsJson);
                return artist;
            }

            throw new ArgumentException("Could not fetch response");
        }

        public virtual void Add(string apiLocation, T entry)
        {
            var serializedObject = JsonConvert.SerializeObject(entry);
            var content = new StringContent(serializedObject);
            var response = this.ServiceClient.PostAsync(apiLocation, content).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException("Could not post to service.");
            }
        }

        public virtual void Modify(string apiLocation, T entry)
        {
            var content = new StringContent(JsonConvert.SerializeObject(entry));
            var response = this.ServiceClient.PutAsync(apiLocation, content).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException("Could not fetch response.");
            }
        }

        public virtual T Delete(string apiLocation)
        {
            HttpResponseMessage response = this.ServiceClient.DeleteAsync(apiLocation).Result;
            if (response.IsSuccessStatusCode)
            {
                var entryString = response.Content.ReadAsStringAsync().Result;
                var entry = JsonConvert.DeserializeObject<T>(entryString);
                return entry;
            }

            throw new ArgumentException("Could not fetch response.");
        }

        protected T Get<T>(string url)
        {
            var response = this.ServiceClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var entriesJson = response.Content.ReadAsStringAsync().Result;
                var entries = JsonConvert.DeserializeObject<T>(entriesJson);
                return entries;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new ArgumentException("Bad request.");
            }

            throw new ArgumentException("Could not fetch response.");
        }

        protected void AddEntry(string url)
        {
            var response = this.ServiceClient.PutAsync(url, null).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException("Could not fetch response.");
            }
        }
    }
}
