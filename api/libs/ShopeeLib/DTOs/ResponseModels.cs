

using Newtonsoft.Json;

namespace ShopeeLib.DTOs
{
    public class ResponseModels
    {
        [JsonProperty("status")]
        public int Status {get; set;}

        [JsonProperty("data")]
        public object? Data {get;set;}
    }
}