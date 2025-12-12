

namespace shopee_sv.Interfaces
{
    public interface IForwardRequest
    {
        public Task GetDetailAsync (string orderId , string shopId );
    }
}