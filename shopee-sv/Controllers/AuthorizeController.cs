using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using shopee_sv.DTOs;

namespace shopee_sv.Controllers
{
    [ApiController]
    [Route("api/shopee/v1")]

    public class AuthorizeController : ControllerBase
    {
        private readonly string PartnerId = "1110154";
        private readonly string PartnerKey = "shpk7a4a5668575672465072434344636379514d756b5654615a484f49637643";

        private static readonly string BaseURL = "https://openplatform.sandbox.test-stable.shopee.sg";

        [HttpGet]
        [Route("authorize-url")]
        public ActionResult GetSignKey([FromQuery] AuthorizationModel model)
        {

            string path = "/api/v2/shop/auth_partner";
            var baseString = $"{PartnerId}{path}{model.TimeStamp}";
            string sign = GenerateSign(baseString, PartnerKey);


            string authorizeUrl =
                $"{BaseURL}/api/v2/shop/auth_partner" +
                $"?partner_id={PartnerId}" +
                $"&redirect={Uri.EscapeDataString(model.RedirectUrl!)}" +
                $"&sign={sign}" +
                $"&timestamp={model.TimeStamp}";

            return Ok(new { authorizeUrl });
        }


        private static string GenerateSign(string data, string secret)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }


        [HttpPost("get-token")]
        public async Task<IActionResult> GetAccessToken([FromBody] ShopeeTokenRequest req)
        {
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            string path = "/api/v2/auth/token/get";

            string baseString = $"{PartnerId}{path}{timestamp}";
            string sign = GenerateSign(baseString, PartnerKey);

            string url =
                $"{BaseURL}/{path}" +
                $"?partner_id={PartnerId}" +
                $"&timestamp={timestamp}" +
                $"&sign={sign}";

            var payload = new
            {
                partner_id = int.Parse(PartnerId),
                code = req.Code,
                shop_id = req.ShopId,
            };

            using var client = new HttpClient();
            var res = await client.PostAsJsonAsync(url, payload);
            var json = await res.Content.ReadAsStringAsync();

            if (!res.IsSuccessStatusCode)
                throw new Exception($"success: false, message: {json}");

            // Save token to DB (optional)
            // TODO: deserialize Shopee token response here

            return Ok(new { success = true, message = "Token stored", data = json });
        }
    }
}