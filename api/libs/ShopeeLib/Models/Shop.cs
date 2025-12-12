using Newtonsoft.Json;
using ShopeeLib.DTOs;

namespace ShopeeLib.Models
{
    public class Shop : ShopModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}