
using ShopeeLib.DTOs;

namespace shopee_sv.Interfaces
{
    public interface IAuthorizeService
    {
        public object GetAthorizeKey (AuthorizationModel model);

        public Task<object> GetAccessTokenAsync(ShopeeTokenRequest req);
    }
}