using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class CartController : Controller
    {
        public async Task<IActionResult> CartIndex()
        {
            return View();
        }
    }
}
