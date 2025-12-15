using Newtonsoft.Json;

namespace ShopeeLib.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
            ModifiedDate = DateTime.UtcNow;
        }
        [JsonProperty("created_date")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("modified_date")]
        public DateTime ModifiedDate { get; set; }
    }
}
