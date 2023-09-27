using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public CartController(ILogger<CartController> logger, IProductService productService, ICartService cartService)
        {
            _logger = logger;
            _productService = productService;
            _cartService = cartService;
        }

        [Authorize]
        public async Task<IActionResult> CartIndex()
        {
            return View(await FindCartByUserId());
        }

        private async Task<CartViewModel> FindCartByUserId()
        {
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _cartService.FindCartByUserId(userId);

            if (response?.CartHeader != null)
            {
                foreach (var detail in response.CartDetails)
                {
                    response.CartHeader.PurchaseAmount += detail.Ammount();
                }
            }

            return response;
        }
    }
}
