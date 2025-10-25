using EcommerceWithPOS.Data;
using EcommerceWithPOS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
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
            try
            {
                return _context.Categories != null ? View(await _context.Categories.ToListAsync()) : Problem("Entity set 'EcommerceDbContext.brands' is null");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            //return View(await _context.Categories.ToListAsync());
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
            var cat = _context.Categories.OrderBy(c => c.Name).ToList();
            ViewBag.Category = new SelectList(cat ?? new List<Category>(), "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = "";
                    string fpath = "";
                    if (_environment != null)
                    {
                        wwwRootPath = _environment.WebRootPath;
                        fpath = wwwRootPath + "/Slider";
                    }
                    else
                    {
                        wwwRootPath = Directory.GetCurrentDirectory();
                        fpath = Path.Combine(wwwRootPath, "/wwwroot/Pictures");
                    }
                    if (category.Images != null)
                    {
                        string extension = Path.GetExtension(category.Images.FileName).ToLower();
                        if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == "..svg" || extension == ".gif")
                        {
                            string fileName = category.Name + extension;
                            string path = Path.Combine(fpath, "Pictures", fileName);
                            using (var fileStream = new FileStream(path, FileMode.Create))
                            {
                                await category.Images.CopyToAsync(fileStream);
                            }
                            category.ImagePath = "/Slider/Pictures/" + fileName;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Please provide .jpg|.jpeg|.png");
                            return View(category);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please provide Photo ");
                    }
                    category.Featured = true;
                    category.IsActive = true;
                    _context.Add(category);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }


            return View(category);
        }


        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            try
            {
                if (id != category.Id)
                {
                    return NotFound();
                }
                var data = await _context.Categories.FindAsync(id);
                string fpath = "";
                string wwwRootPath = "";
                if (_environment != null)
                {
                    wwwRootPath = _environment.WebRootPath;
                    fpath = wwwRootPath + "/Slider";
                }
                else
                {
                    wwwRootPath = Directory.GetCurrentDirectory();
                    fpath = Path.Combine(wwwRootPath, "/wwwroot/Slider");
                }
                if (category.Images != null)
                {
                    if (data != null)
                    {
                        string npath = data.ImagePath.Replace("~", "");
                        string rootpath = wwwRootPath + npath;
                        if (System.IO.File.Exists(rootpath))
                        {
                            System.IO.File.Delete(rootpath);
                        }
                        string extension = Path.GetExtension(category.Images.FileName).ToLower();
                        if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == ".svg" || extension == ".gif")
                        {
                            string fileName = category.Name + extension;
                            //string path = Path.Combine(wwwRootPath, "/Slider", fileName);
                            string path = Path.Combine(fpath, "Pictures", fileName);
                            using (var fileStrem = new FileStream(path, FileMode.Create))
                            {
                                await category.Images.CopyToAsync(fileStrem);
                            }
                            category.ImagePath = "/Slider/Pictures/" + fileName;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Please provide .jpg|.jpeg|.png");
                            return View(category);
                        }
                    }
                }
                else
                {
                    data.ImagePath = category.ImagePath;
                }
                data.Id = category.Id;
                data.Name = category.Name;
                data.Slug = category.Slug;
                data.ShortDescription = category.ShortDescription;
                data.ImagePath = category.ImagePath;
                data.IsActive = category.IsActive;
                data.Featured = category.Featured;
                data.UpdatedAt = category.UpdatedAt;

                _context.Update(data);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(category);
            }


            //if (id != category.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(category);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!CategoryExists(category.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                string fpath = "";
                string wwwRootPath = "";
                if (_environment != null)
                {
                    wwwRootPath = _environment.WebRootPath;
                    fpath = wwwRootPath + "/Slider";
                }
                else
                {
                    wwwRootPath = Directory.GetCurrentDirectory();
                    fpath = Path.Combine(wwwRootPath, "/wwwroot/Slider");
                }
                if (_context.Categories == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Brands'  is null.");
                }
                var cat = await _context.Categories.FindAsync(id);
                if (cat != null)
                {
                    string path = cat.ImagePath.Replace("~", "");
                    _context.Categories.Remove(cat);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        string rootPath = wwwRootPath + path;
                        if (System.IO.File.Exists(rootPath))
                        {
                            System.IO.File.Delete(rootPath);
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            //var category = await _context.Categories.FindAsync(id);
            //if (category != null)
            //{
            //    _context.Categories.Remove(category);
            //}

            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
