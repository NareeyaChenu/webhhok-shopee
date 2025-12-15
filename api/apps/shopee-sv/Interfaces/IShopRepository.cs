

using ShopeeLib.DTOs;

namespace shopee_sv.Interfaces
{
    public interface IShopRepository
    {
        public Task InsertAsync (ShopModel shopModel);
    }
}