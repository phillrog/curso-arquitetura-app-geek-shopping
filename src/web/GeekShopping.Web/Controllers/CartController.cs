using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace GeekShopping.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly ICouponService _couponService;

        public CartController(ILogger<CartController> logger, IProductService productService, ICartService cartService,
            ICouponService couponService)
        {
            _logger = logger;
            _productService = productService;
            _cartService = cartService;
            _couponService = couponService;
        }

        [Authorize]
        public async Task<IActionResult> CartIndex()
        {
            return View(await FindCartByUserId());
        }

        public async Task<IActionResult> Remove(int id)
        {
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _cartService.RemoveItemFromCart(id);

            if (response)
            {
                return RedirectToAction("CartIndex");
            }

            return View();
        }

        [HttpPost]
        [ActionName("ApplyCoupon")]
        public async Task<IActionResult> ApplyCoupon(CartViewModel model)
        {
            var response = await _cartService.ApplyCoupon(model);

            if (response)
            {
                return RedirectToAction("CartIndex");
            }

            return View();
        }

        [HttpPost]
        [ActionName("RemoveCoupon")]
        public async Task<IActionResult> RemoveCoupon()
        {
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
            var response = await _cartService.RemoveCoupon(userId);

            if (response)
            {
                return RedirectToAction("CartIndex");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            return View(await FindCartByUserId());
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CartHeaderViewModel model)
        {
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
            var response = await _cartService.Checkout(model);

            if (response == null)
            {
                return RedirectToAction("Confirmation");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Confirmation()
        {
            return View();
        }

        private async Task<CartViewModel> FindCartByUserId()
        {
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _cartService.FindCartByUserId(userId);

            if (response == null) return response;

            await CalcDiscount(response.CartHeader);
            response.CalcPurchaseAmount();            

            return response;
        }

        private async Task CalcDiscount(CartHeaderViewModel cartHeader)
        {
            if (cartHeader != null && cartHeader.HasCoupon())
            {
                var coupon = await _couponService.GetCoupon(cartHeader.CouponCode);

                if (coupon?.CouponCode != null)
                {
                    cartHeader.SetDiscountTotal(coupon.DiscountAmount);
                }
            }
        }
    }
}
