using EcommerceWithPOS.Data;
using EcommerceWithPOS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWithPOS.Controllers
{
    public class ThanaController : Controller
    {
        private readonly EcommerceDbContext _context;
        public ThanaController(EcommerceDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetThana()
        {
            var thana = _context.Thanas.Include(c => c.District).ToList();
            return Json(thana);
        }


        [HttpPost]
        public JsonResult Insert([FromBody] Thana thana)
        {
            if (ModelState.IsValid)
            {
                _context.Thanas.Add(thana);
                _context.SaveChanges();
                return Json("Thana details saved.");
            }
            //else
            //{
            return Json("Model validation failed.");
            //}
        }


        [HttpGet]
        public JsonResult Edit(int id)
        {
            var thana = _context.Thanas.Find(id);
            return Json(thana);
        }

        [HttpPost]
        public JsonResult Update([FromBody] Thana thana)
        {
            if (ModelState.IsValid)
            {
                _context.Thanas.Update(thana);
                _context.SaveChanges();
                return Json("Thana details updated.");
            }
            return Json("Model validation failed.");
        }


        [HttpPost]
        public JsonResult Delete(int id)
        {
            var thana = _context.Thanas.Find(id);
            if (thana != null)
            {
                _context.Thanas.Remove(thana);
                _context.SaveChanges();
                return Json("Thana details deleted.");
            }
            return Json("Thana details not found with id {id}.");
        }
    }
}
