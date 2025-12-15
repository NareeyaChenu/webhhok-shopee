

using Newtonsoft.Json;

namespace ShopeeLib.DTOs
{
    public class TokenResponseModel
    {
        [JsonProperty("refresh_token")]
        public string? RefreshToken { get; set; }

        [JsonProperty("access_token")]
        public string? AccessToken { get; set; }

        [JsonProperty("expire_in")]
        public int ExpireIn { get; set; }

        [JsonProperty("request_id")]
        public string? RequestId { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}