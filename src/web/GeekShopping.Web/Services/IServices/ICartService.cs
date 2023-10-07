using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface ICartService
    {
        Task<CartViewModel> FindCartByUserId(string userId);
        Task<CartViewModel> AddItemToCart(CartViewModel cart);
        Task<CartViewModel> UpdateToCart(CartViewModel cart);
        Task<bool> RemoveItemFromCart(int cartId);
        Task<bool> ApplyCoupon(CartViewModel cart);
        Task<bool> RemoveCoupon(string userId);
        Task<bool> ClearCart(int userId);
        Task<CartHeaderViewModel> Checkout(CartHeaderViewModel cartHeader);
    }
}
