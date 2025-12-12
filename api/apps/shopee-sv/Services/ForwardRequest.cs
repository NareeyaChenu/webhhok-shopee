
using System.Security.Cryptography;
using System.Text;
using shopee_sv.Interfaces;

namespace shopee_sv.Services
{
    public class ForwardRequest : IForwardRequest
    {
        public async Task GetDetailAsync(string orderId, string shopId)
        {

            string baseURL = "https://openplatform.sandbox.test-stable.shopee.sg";
            string path = "api/v2/order/get_order_detail";

            string accessToken = "";
            int partnerId = 0;

            string partnerKey = "";

            long shopIdLong = long.Parse(shopId);


            // long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            string signKey = CalculateHash(timestamp, partnerId, shopIdLong, path, partnerKey, accessToken);
            string fullURL = $"{baseURL}/{path}?access_token={accessToken}&order_sn_list={orderId}&partner_id={partnerId}&request_order_status_pending=true&response_optional_fields=total_amount&shop_id={shopId}&sign={signKey}&timestamp={timestamp}";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, fullURL);
            var response = await client.SendAsync(request);

            Console.WriteLine(await response.Content.ReadAsStringAsync());

        }


        public static string CalculateHash(long timestamp, int partnerId, long shopId, string apiPath, string partnerKey, string accessToken)
        {
            // Build base string: {partner_id}{path}{timestamp}
            string baseString = $"{partnerId}/{apiPath}{timestamp}{accessToken}{shopId}";

            Console.WriteLine(baseString);

            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(partnerKey)))
            {
                byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(baseString));

                string sign = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                Console.WriteLine(sign);
                return sign;
            }


        }
    }
}