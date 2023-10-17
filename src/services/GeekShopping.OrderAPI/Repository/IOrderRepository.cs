using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.OrderAPI.Model;

namespace GeekShopping.OrderAPI.Repository
{
    public interface IOrderRepository
    {

        Task<bool> AddOrder(OrderHeader orderHeader);
        Task UpdateOrderPaymentStatus(int orderheaderId, bool paid);
    }
}
