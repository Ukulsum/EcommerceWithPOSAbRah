using EcommerceWithPOS.Data;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWithPOS.Controllers
{
    public class DivisionController : Controller
    {
        private readonly EcommerceDbContext _context;

        public DivisionController(EcommerceDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
