using EcommerceWithPOS.Data;
using EcommerceWithPOS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWithPOS.Controllers
{
    public class ColorController : Controller
    {
        private readonly EcommerceDbContext _context;

        public ColorController(EcommerceDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[NonAction]
        public JsonResult GetColors()
        {
            var colors = _context.Colors.ToList();
            return Json(colors);
        }


        [HttpPost]
        public JsonResult Insert([FromBody] ProductColor color)
        {
            if (ModelState.IsValid)
            {
                _context.Colors.Add(color);
                _context.SaveChanges();
                return Json("Color details saved.");
            }
            //else
            //{
                return Json("Model validation failed.");
            //}
        }


        [HttpGet]
        public JsonResult Edit(int id)
        {
            var color = _context.Colors.Find(id);
            return Json(color);
        }

        [HttpPost]
        public JsonResult Update([FromBody] ProductColor color)
        {
            if (ModelState.IsValid)
            {
                _context.Colors.Update(color);
                _context.SaveChanges();
                return Json("Color details updated.");
            }
            return Json("Model validation failed."); 
        }


        [HttpPost]
        public JsonResult Delete(int id)
        {
            var color = _context.Colors.Find(id);
            if(color != null)
            {
                _context.Colors.Remove(color);
                _context.SaveChanges();
                return Json("Color details deleted.");
            }
            return Json("Color details not found with id {id}.");
        }
    }
}
