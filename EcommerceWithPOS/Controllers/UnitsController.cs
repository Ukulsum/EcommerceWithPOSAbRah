using EcommerceWithPOS.Data;
using EcommerceWithPOS.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWithPOS.Controllers
{
    public class UnitsController : Controller
    {
        private readonly EcommerceDbContext _context;

        public UnitsController(EcommerceDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetUnits()
        {
            var colors = _context.Units.ToList();
            return Json(colors);
        }


        [HttpPost]
        public JsonResult Insert([FromBody] Unit unit)
        {
            if (ModelState.IsValid)
            {
                _context.Units.Add(unit);
                _context.SaveChanges();
                return Json("Unit details saved.");
            }
            //else
            //{
            return Json("Model validation failed.");
            //}
        }


        [HttpGet]
        public JsonResult Edit(int id)
        {
            var unit = _context.Units.Find(id);
            return Json(unit);
        }

        [HttpPost]
        public JsonResult Update([FromBody] Unit unit)
        {
            if (ModelState.IsValid)
            {
                _context.Units.Update(unit);
                _context.SaveChanges();
                return Json("Unit details updated.");
            }
            return Json("Model validation failed.");
        }


        [HttpPost]
        public JsonResult Delete(int id)
        {
            var unit = _context.Units.Find(id);
            if (unit != null)
            {
                _context.Units.Remove(unit);
                _context.SaveChanges();
                return Json("Unit details deleted.");
            }
            return Json("Unit details not found with id {id}.");
        }
    }
}
