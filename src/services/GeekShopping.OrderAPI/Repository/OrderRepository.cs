using GeekShopping.OrderAPI.Model;
using GeekShopping.OrderAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.OrderAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<OrderContext> _context;

        public OrderRepository(DbContextOptions<OrderContext> context)
        {
            _context = context;
        }

        public async Task<bool> AddOrder(OrderHeader orderHeader)
        {
            if (orderHeader == null) return false;

            await using var db = new OrderContext(_context);

            db.OrderHeaders.Add(orderHeader);

            await db.SaveChangesAsync();
            return true;
        }

        public async Task UpdateOrderPaymentStatus(int orderheaderId, bool paid)
        {
            await using var db = new OrderContext(_context);
            var header = db.OrderHeaders.FirstOrDefault(x => x.Id == orderheaderId);
            if (header != null)
            {
                header.PaymentStatus = paid;
                await db.SaveChangesAsync();
            }
        }
    }
}
