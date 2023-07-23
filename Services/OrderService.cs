using Fast_Food_online.Data;
using Fast_Food_online.Models;

namespace Fast_Food_online.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext context;
        private readonly ShoppingCart cart;

        public OrderService(ApplicationDbContext context,ShoppingCart cart)
        {
            this.context = context;
            this.cart = cart;
        }
        public async Task StoreOrderAsync(Order order)
        {
            order.orderdate = DateTime.Now;
            order.OrderTotal = cart.GetShoppingCartTotal();
            var SCItems=cart.GetShoppingCartItems();
            order.Items = new List<OrderItem>();
            foreach (var item in SCItems)
            {
                var OItem = new OrderItem()
                {
                    Amount=item.Amount,
                    Price=(decimal)item.Item.Price,
                    productId=item.Item.Id,
                };
                order.Items.Add(OItem);
                context.OrderItems.Add(OItem);
            }
            context.Orders.Add(order);
            await context.SaveChangesAsync();
            
        }
    }
}
