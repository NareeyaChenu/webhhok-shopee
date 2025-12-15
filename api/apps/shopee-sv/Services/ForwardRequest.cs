
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using shopee_sv.Interfaces;
using ShopeeLib.DTOs;
using ShopeeLib.Services;

namespace shopee_sv.Services
{
    public class ForwardRequest : IForwardRequest
    {
        private readonly string PartnerId = "1110154";
        private readonly string PartnerKey = "shpk7a4a5668575672465072434344636379514d756b5654615a484f49637643";
        private static readonly string BaseURL = "https://openplatform.sandbox.test-stable.shopee.sg";
        public ForwardRequest()
        {

        }

        public async Task<TokenResponseModel> GetAccessTokenAsync(ShopeeTokenRequest model)
        {
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            string path = "/api/v2/auth/token/get";

            string baseString = $"{PartnerId}{path}{timestamp}";
            string sign = SignatureHelper.GenerateSignKey(baseString, PartnerKey);

            string url =
                $"{BaseURL}/{path}" +
                $"?partner_id={PartnerId}" +
                $"&timestamp={timestamp}" +
                $"&sign={sign}";

            var payload = new
            {
                partner_id = int.Parse(PartnerId),
                code = model.Code,
                shop_id = model.ShopId,
            };

            using var client = new HttpClient();
            var res = await client.PostAsJsonAsync(url, payload);
            var json = await res.Content.ReadAsStringAsync();

            if (!res.IsSuccessStatusCode)
                throw new Exception($"success: false, message: {json}");



            // Save token to DB (optional)
            // TODO: deserialize Shopee token response here

            var tokenModel = JsonConvert.DeserializeObject<TokenResponseModel>(json);

            return tokenModel!;
        }

        public async Task GetDetailAsync(string orderId, string shopId)
        {
            throw new NotImplementedException();
        }

        public async Task<ShopResponseModel> GetShopInfoAsync(string shopId, string accessToken)
        {
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            string path = "/api/v2/shop/get_shop_info";

            string baseString = $"{PartnerId}{path}{timestamp}{accessToken}{shopId}";


            string sign = SignatureHelper.GenerateSignKey(baseString, PartnerKey);

            string url =
                $"{BaseURL}/{path}" +
                $"?partner_id={PartnerId}" +
                $"&timestamp={timestamp}" +
                $"&sign={sign}" +
                $"&shop_id={shopId}" +
                $"&access_token={accessToken}";


            using var client = new HttpClient();
            var res = await client.GetAsync(url);
            var json = await res.Content.ReadAsStringAsync();

            if (!res.IsSuccessStatusCode)
                throw new Exception($"success: false, message: {json}");
            

            var shop = JsonConvert.DeserializeObject<ShopResponseModel>(json);

            return shop!;

        }
    }
}