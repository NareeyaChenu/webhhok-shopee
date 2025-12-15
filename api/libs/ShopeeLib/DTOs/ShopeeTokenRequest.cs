

using Newtonsoft.Json;

namespace ShopeeLib.DTOs
{
    public class ShopeeTokenRequest
    {
        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("shop_id")]
        public long ShopId { get; set; }
    }
}