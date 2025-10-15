using EcommerceWithPOS.Data;
using EcommerceWithPOS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWithPOS.Controllers
{
    public class CountryController : Controller
    {
        private readonly EcommerceDbContext _context;

        public CountryController(EcommerceDbContext context)
        {

            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetCountry()
        {
            var country = _context.Countries.Include(c => c.Currency).ToList();
            return Json(country);
        }


        [HttpPost]
        public JsonResult Insert([FromBody] Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Add(country);
                _context.SaveChanges();
                return Json("Country details saved.");
            }
            //else
            //{
            return Json("Model validation failed.");
            //}
        }


        [HttpGet]
        public JsonResult Edit(int id)
        {
            var country = _context.Countries.Find(id);
            return Json(country);
        }

        [HttpPost]
        public JsonResult Update([FromBody] Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Update(country);
                _context.SaveChanges();
                return Json("Country details updated.");
            }
            return Json("Model validation failed.");
        }


        [HttpPost]
        public JsonResult Delete(int id)
        {
            var country = _context.Countries.Find(id);
            if (country != null)
            {
                _context.Countries.Remove(country);
                _context.SaveChanges();
                return Json("Country details deleted.");
            }
            return Json("country details not found with id {id}.");
        }
    }
}
