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
        public JsonResult Insert([FromBody] Color color)
        {
            if (ModelState.IsValid)
            {
                _context.Colors.Add(color);
                _context.SaveChanges();
                return Json("Color details saved.");
            }
            else
            {
                return Json("Model validation failed.");
            }
        }



        //public async Task<IActionResult> Index()
        //{
        //    var colors = await _context.Colors.ToListAsync();
        //    return View(colors);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(Color color)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        _context.Colors.Add(color);
        //        await _context.SaveChangesAsync();
        //        return Json(new { success =  true });
        //    }
        //    return PartialView("_CreateEdit", color);
        //}


        //public async Task<IActionResult> Edit(int id)
        //{
        //    var color = await _context.Colors.FindAsync(id);
        //    return PartialView("_CreateEdit", color);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(Color color)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Colors.Update(color);
        //        await _context.SaveChangesAsync();
        //        return Json(new { success = true });
        //    }
        //    return PartialView("_CreateEdit", color);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var color = await _context.Colors.FindAsync(id);
        //    if (color == null) return Json(new { success = false });

        //    _context.Colors.Remove(color);
        //    await _context.SaveChangesAsync();
        //    return Json(new { success = true });
        //}
    }
}
