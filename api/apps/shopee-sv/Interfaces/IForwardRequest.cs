

using ShopeeLib.DTOs;

namespace shopee_sv.Interfaces
{
    public interface IForwardRequest
    {
        public Task GetDetailAsync (string orderId , string shopId );

        public Task<TokenResponseModel> GetAccessTokenAsync (ShopeeTokenRequest modl);


        public Task<ShopResponseModel> GetShopInfoAsync (string shopId , string accessToken);
    }
}