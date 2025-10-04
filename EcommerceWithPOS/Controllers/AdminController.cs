using Microsoft.AspNetCore.Mvc;

namespace EcommerceWithPOS.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
