

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ShopeeLib.DTOs
{
    public class AuthorizationModel
    {
        [JsonProperty("redirect_url")]
        [FromQuery(Name = "redirect_url")]
        [Required]
        public string? RedirectUrl {get; set;}

        [JsonProperty("timestamp")]
        [FromQuery(Name = "timestamp")]
        [Required]
        public long TimeStamp {get; set;}
    }
}