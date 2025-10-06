using EcommerceWithPOS.Data;
using EcommerceWithPOS.Migrations;
using EcommerceWithPOS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWithPOS.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly EcommerceDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CategoriesController(EcommerceDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Your cart is empty or data is invalid.";
                string msg = "";
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    msg += error.ErrorMessage;
                }
                ModelState.AddModelError("", msg);
                return View(category);
            }


            //await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Determine root directories
                string wwwRootPath = _environment?.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                string bannerRoot = Path.Combine(wwwRootPath, "Slider");


                // Ensure required directories exist
                Directory.CreateDirectory(Path.Combine(bannerRoot, "Pictures"));


                // ======= Logo Upload =======
                if (category.Images != null && category.Images.Length > 0)
                {
                    string extension = Path.GetExtension(category.Images.FileName).ToLower();
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                    {
                        string fileName = $"{category.Name}_logo{extension}";
                        string savePath = Path.Combine(bannerRoot, "Logo", fileName);

                        using (var fileStream = new FileStream(savePath, FileMode.Create))
                        {
                            await category.Images.CopyToAsync(fileStream);
                        }

                        category.ImagePath = $"/Slider/Pictures/{fileName}";
                    }
                    else
                    {
                        ModelState.AddModelError("", "Logo must be .jpg, .jpeg, or .png format.");
                        return View(category);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please upload a logo file.");
                    return View(category);
                }


               

                // ======= Save Developer/Agent =======
                category.CreatedAt = DateTime.Now;

                _context.Add(category);
                if (await _context.SaveChangesAsync() > 0)
                {

                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(category);
            }

            return View(category);


            //if (ModelState.IsValid)
            //{
            //    _context.Add(category);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ImagePath,ParentId,PageTitle,ShortDescription,Slug,Icon,Featured,IsActive,CreatedAt,UpdatedAt")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
