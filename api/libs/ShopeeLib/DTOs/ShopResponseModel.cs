

using Newtonsoft.Json;

namespace ShopeeLib.DTOs
{
    public class ShopResponseModel
    {
        [JsonProperty("shop_name")]
        public string? ShopName {get; set;}

        [JsonProperty("auth_time")]
        public long? AuthTime {get; set;}
        [JsonProperty("expire_time")]
        public long? ExpireTime {get; set;}
    }
}