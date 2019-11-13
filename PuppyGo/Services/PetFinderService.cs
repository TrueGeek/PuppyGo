using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PuppyGo.Services
{

    public class PetFinderService
    {

        private const string clientId = "nDKb4LL42PtMtfMzorxGD6hlf2KeoXJi1Q916b6CZRC6UaiJBI";
        private const string clientSecret = "UDZBWjGJWDw3WyAswM4kIBBnZEMw2VCa5OkIT3ys";

        private const string apiBaseUrl = "https://api.petfinder.com";

        public async Task<List<Models.Petfinder.Animal>> GetDogs()
        {

            if (Helpers.Statics.PetFinderAccessTokenExpirationTimeUtc <= DateTime.UtcNow.AddSeconds(30))
            {
                await GetAccessToken();
            }

            var location = await new LocationService().GetUsersLocation();

            using (var webClient = new WebClient())
            {

                webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Helpers.Statics.PetFinderAccessToken);

                var url = $"{apiBaseUrl}/v2/animals/?type=dog&location={location.Latitude},{location.Longitude}&status=adoptable";

                var json = webClient.DownloadString(url);

                var response = JsonConvert.DeserializeObject<Models.Petfinder.GetAnimalsResponse>(json);

                return response.Animals;

            }

        }

        public async Task GetDog(int dogId)
        {

        }

        private async Task<bool> GetAccessToken()
        {

            var content = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "client_id", clientId },
                { "client_secret", clientSecret },
            };

            var httpRequest = new HttpRequestMessage()
            {
                RequestUri = new Uri(apiBaseUrl + "/v2/oauth2/token"),
                Method = HttpMethod.Post,
                Content = new FormUrlEncodedContent(content),
            };

            using (var httpClient = new HttpClient())
            {

                using (var httpResponse = await httpClient.SendAsync(httpRequest))
                {

                    // check for failure
                    if (!httpResponse.IsSuccessStatusCode)
                    {
                        Helpers.Statics.PetFinderAccessToken = null;
                        Helpers.Statics.PetFinderAccessTokenExpirationTimeUtc = DateTime.MinValue;
                        return false;
                    }

                    // convert response to object
                    var responseAsString = await httpResponse.Content.ReadAsStringAsync();
                    var responseAsObject = JsonConvert.DeserializeObject<Models.Petfinder.AuthResponse>(responseAsString);

                    // save response
                    Helpers.Statics.PetFinderAccessToken = responseAsObject.AccessToken;
                    Helpers.Statics.PetFinderAccessTokenExpirationTimeUtc = responseAsObject.ExpirationAtTimeUtc;
                    return true;

                }

            }

        }

    }

}
