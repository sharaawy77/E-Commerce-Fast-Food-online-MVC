using Fast_Food_online.Models;

namespace Fast_Food_online.Services
{
    public interface IOrderService
    {
        public Task StoreOrderAsync(Order order);
    }
}
