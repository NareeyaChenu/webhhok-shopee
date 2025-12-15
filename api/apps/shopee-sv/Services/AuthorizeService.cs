

using shopee_sv.Interfaces;
using ShopeeLib.DTOs;
using ShopeeLib.Services;

namespace shopee_sv.Services
{
    public class AuthorizeService : IAuthorizeService
    {

        private readonly string PartnerId = "1110154";
        private readonly string PartnerKey = "shpk7a4a5668575672465072434344636379514d756b5654615a484f49637643";
        private static readonly string BaseURL = "https://openplatform.sandbox.test-stable.shopee.sg";

        private readonly IForwardRequest _forReq;

        private readonly IShopRepository _shopRepo;

        public AuthorizeService(IForwardRequest forReq, IShopRepository shopRepo)
        {
            _forReq = forReq;
            _shopRepo = shopRepo;
        }

        public object GetAthorizeKey(AuthorizationModel model)
        {

            string path = "/api/v2/shop/auth_partner";
            var baseString = $"{PartnerId}{path}{model.TimeStamp}";
            string sign = SignatureHelper.GenerateSignKey(baseString, PartnerKey);


            string authorizeUrl =
                $"{BaseURL}/api/v2/shop/auth_partner" +
                $"?partner_id={PartnerId}" +
                $"&redirect={Uri.EscapeDataString(model.RedirectUrl!)}" +
                $"&sign={sign}" +
                $"&timestamp={model.TimeStamp}";

            return new { authorizeUrl };
        }

        public async Task<object> GetAccessTokenAsync(ShopeeTokenRequest req)
        {
            var tokenRes = await _forReq.GetAccessTokenAsync(req);

            var shop = await _forReq.GetShopInfoAsync(req.ShopId.ToString(), tokenRes.AccessToken!);



            var shopModel = new ShopModel
            {
                AccessToken = tokenRes.AccessToken,
                RefreshToken = tokenRes.RefreshToken,
                ShopName = shop.ShopName,
                ExpireDatetime = shop.ExpireTime
            };


            await _shopRepo.InsertAsync(shopModel);
            return new ResponseModels();
        }
    }
}