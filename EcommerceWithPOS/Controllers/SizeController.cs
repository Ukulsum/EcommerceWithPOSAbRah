using EcommerceWithPOS.Data;
using EcommerceWithPOS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace EcommerceWithPOS.Controllers
{
    public class SizeController : Controller
    {
        private readonly EcommerceDbContext _context;

        public SizeController(EcommerceDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetSizes()
        {
            var colors = _context.PSizes.ToList();
            return Json(colors);
        }


        [HttpPost]
        public JsonResult Insert([FromBody] PSize size)
        {
            if (ModelState.IsValid)
            {
                _context.PSizes.Add(size);
                _context.SaveChanges();
                return Json("Size details saved.");
            }
            //else
            //{
            return Json("Model validation failed.");
            //}
        }


        [HttpGet]
        public JsonResult Edit(int id)
        {
            var color = _context.PSizes.Find(id);
            return Json(color);
        }

        [HttpPost]
        public JsonResult Update([FromBody] PSize size)
        {
            if (ModelState.IsValid)
            {
                _context.PSizes.Update(size);
                _context.SaveChanges();
                return Json("Size details updated.");
            }
            return Json("Model validation failed.");
        }


        [HttpPost]
        public JsonResult Delete(int id)
        {
            var color = _context.Colors.Find(id);
            if (color != null)
            {
                _context.Colors.Remove(color);
                _context.SaveChanges();
                return Json("Color details deleted.");
            }
            return Json("Color details not found with id {id}.");
        }
    }
}
