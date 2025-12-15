

using Newtonsoft.Json;
using shopee_sv.DBContext;
using shopee_sv.Interfaces;
using ShopeeLib.DTOs;
using ShopeeLib.Models;

namespace shopee_sv.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly AppDbContext _db;

        public ShopRepository(AppDbContext db)
        {
            _db = db;
        }

        public  async Task InsertAsync(ShopModel shopModel)
        {
            var shop = JsonConvert.DeserializeObject<Shop>(JsonConvert.SerializeObject(shopModel))!;


            await _db.AddAsync(shop);

            await _db.SaveChangesAsync();
        }
    }
}