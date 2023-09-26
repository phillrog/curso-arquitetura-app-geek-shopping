using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Reflection;

namespace GeekShopping.Web.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/cart";

        public CartService(HttpClient client)
        {
            _client = client;
        }
        public async Task<CartViewModel> AddItemToCart(CartViewModel cart)
        {
            var response = await _client.PostAsJson($"{BasePath}/add-cart", cart);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CartViewModel>();
            else throw new Exception("Something went wrong when calling API");
        }

        public Task<bool> ApplyCoupon(CartViewModel cart, string couponCode)
        {
            throw new NotImplementedException();
        }

        public Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ClearCart(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartViewModel> FindCartByUserId(string userId)
        {
            var response = await _client.GetAsync($"{BasePath}/find-cart/{userId}");
            return await response.ReadContentAs<CartViewModel>();
        }

        public Task<bool> RemoveCoupon(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveItemFromCart(int cartId)
        {
            var response = await _client.DeleteAsync($"{BasePath}/remove-cart/{cartId}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<CartViewModel> UpdateToCart(CartViewModel cart)
        {
            var response = await _client.PutAsJson($"{BasePath}/update-cart", cart);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CartViewModel>();
            else throw new Exception("Something went wrong when calling API");
        }
    }
}
