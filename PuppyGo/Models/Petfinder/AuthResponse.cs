using System;
using Newtonsoft.Json;

namespace PuppyGo.Models.Petfinder
{

    public class AuthResponse
    {

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresInSeconds { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        public DateTime ExpirationAtTimeUtc => DateTime.UtcNow.AddSeconds(ExpiresInSeconds);

    }

}
