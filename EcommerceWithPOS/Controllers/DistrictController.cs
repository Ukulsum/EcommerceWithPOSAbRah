using EcommerceWithPOS.Data;
using EcommerceWithPOS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWithPOS.Controllers
{
    public class DistrictController : Controller
    {
        private readonly EcommerceDbContext _context;

        public DistrictController(EcommerceDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetDistrict()
        {
            var district = _context.Districts.Include(c => c.Division).ToList();
            return Json(district);
        }


        [HttpPost]
        public JsonResult Insert([FromBody] District district)
        {
            if (ModelState.IsValid)
            {
                _context.Districts.Add(district);
                _context.SaveChanges();
                return Json("District details saved.");
            }
            //else
            //{
            return Json("Model validation failed.");
            //}
        }


        [HttpGet]
        public JsonResult Edit(int id)
        {
            var district = _context.Districts.Find(id);
            return Json(district);
        }

        [HttpPost]
        public JsonResult Update([FromBody] District district)
        {
            if (ModelState.IsValid)
            {
                _context.Districts.Update(district);
                _context.SaveChanges();
                return Json("District details updated.");
            }
            return Json("Model validation failed.");
        }


        [HttpPost]
        public JsonResult Delete(int id)
        {
            var district = _context.Districts.Find(id);
            if (district != null)
            {
                _context.Districts.Remove(district);
                _context.SaveChanges();
                return Json("District details deleted.");
            }
            return Json("District details not found with id {id}.");
        }
    }
}
