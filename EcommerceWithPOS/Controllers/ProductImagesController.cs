using EcommerceWithPOS.Data;
using EcommerceWithPOS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWithPOS.Controllers
{
    public class ProductImagesController : Controller
    {
        private readonly EcommerceDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public ProductImagesController(EcommerceDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            try
            {
                var data = _context.ProductImages.Include(p => p.Product).ThenInclude(c => c.Category);
                return View(data);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            } 
        }

        public IActionResult Create()
        {
            try
            {
                ViewBag.productName = new SelectList(_context.Products, "Id", "Name");
                return View();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductImage productImage, List<IFormFile> Images)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    ViewData["ProductName"] = new SelectList(_context.Products, "Id", "Name");
                    return View(productImage);
                }
                if(Images is null || Images.Count == 0)
                {
                    ModelState.AddModelError("", "No Image files were uploaded");
                    ViewData["ProductName"] = new SelectList(_context.Products, "Id", "Name");
                    return View(productImage);
                }

                string imagePath = Path.Combine(_environment.WebRootPath, "Pictures");
                if (!Directory.Exists(imagePath))
                {
                    Directory.CreateDirectory(imagePath);
                }
                
                foreach (var image in Images)
                {
                    string fileName = Path.GetFileName(image.FileName);
                    string fullPath = Path.Combine(imagePath, fileName);
                    using(var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }
                    productImage.ImagePath = "/Pictures/" + fileName;
                    _context.Add(productImage);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {

            }
            return View(productImage);
        }
    }
}
