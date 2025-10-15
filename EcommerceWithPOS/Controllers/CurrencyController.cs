using EcommerceWithPOS.Data;
using EcommerceWithPOS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWithPOS.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly EcommerceDbContext _context;

        public CurrencyController(EcommerceDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetCurrency()
        {
            var currency = _context.Currencies.ToList();
            return Json(currency);
        }


        [HttpPost]
        public JsonResult Insert([FromBody] Currency currency)
        {
            if (ModelState.IsValid)
            {
                _context.Currencies.Add(currency);
                _context.SaveChanges();
                return Json("Currency details saved.");
            }
            //else
            //{
            return Json("Model validation failed.");
            //}
        }


        [HttpGet]
        public JsonResult Edit(int id)
        {
            var currency = _context.Currencies.Find(id);
            return Json(currency);
        }

        [HttpPost]
        public JsonResult Update([FromBody] Currency currency)
        {
            if (ModelState.IsValid)
            {
                _context.Currencies.Update(currency);
                _context.SaveChanges();
                return Json("Currency details updated.");
            }
            return Json("Model validation failed.");
        }


        [HttpPost]
        public JsonResult Delete(int id)
        {
            var currency = _context.Currencies.Find(id);
            if (currency != null)
            {
                _context.Currencies.Remove(currency);
                _context.SaveChanges();
                return Json("Currency details deleted.");
            }
            return Json("Currency details not found with id {id}.");
        }
    }
}
