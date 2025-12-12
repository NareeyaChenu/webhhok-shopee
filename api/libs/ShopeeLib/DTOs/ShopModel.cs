
using Newtonsoft.Json;
using ShopeeLib.Models;
namespace ShopeeLib.DTOs
{
    public class ShopModel : BaseEntity
    {
        [JsonProperty("shop_name")]
        public string? ShopName {get;  set;}

        [JsonProperty("access_token")]
        public string? AccessToken {get; set;}
        
        [JsonProperty("refresh_token")]
        public string? RefreshToken {get; set;}

        [JsonProperty("expire_datetime")]
        public long? ExpireDatetime {get; set;}
    }
}