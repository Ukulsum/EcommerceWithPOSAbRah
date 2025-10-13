using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcommerceWithPOS.Data;
using EcommerceWithPOS.Models;

namespace EcommerceWithPOS.Controllers
{
    public class BrandsController : Controller
    {
        private readonly EcommerceDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public BrandsController(EcommerceDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Brands
        public async Task<IActionResult> Index()
        {
            try
            {
                return _context.Brands != null ? View(await _context.Brands.ToListAsync()) : Problem("Entity set 'EcommerceDbContext.brands' is null");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            //return View(await _context.Brands.ToListAsync());
        }

        // GET: Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var brand = await _context.Brands
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (brand == null)
                {
                    return NotFound();
                }

                return View(brand);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = "";
                    string fpath = "";
                    if(_environment != null)
                    {
                        wwwRootPath = _environment.WebRootPath;
                        fpath = wwwRootPath + "/Slider";
                    }
                    else
                    {
                        wwwRootPath = Directory.GetCurrentDirectory();
                        fpath = Path.Combine(wwwRootPath, "/wwwroot/Pictures");
                    }
                    if(brand.Logo != null)
                    {
                        string extension = Path.GetExtension(brand.Logo.FileName).ToLower();
                        if(extension == ".jpg" ||  extension == ".png" || extension == ".jpeg" || extension == "..svg" || extension == ".gif")
                        {
                            string fileName = brand.Name + extension;
                            string path = Path.Combine(fpath, "Pictures", fileName);
                            using (var fileStream = new FileStream(path, FileMode.Create))
                            {
                                await brand.Logo.CopyToAsync(fileStream);
                            }
                            brand.LogoPath = "/Slider/Pictures/" + fileName;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Please provide .jpg|.jpeg|.png");
                            return View(brand);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please provide Photo ");
                    }
                    brand.IsActive = true;
                    _context.Add(brand);
                    if(await _context.SaveChangesAsync() > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }


            //if (ModelState.IsValid)
            //{
            //    _context.Add(brand);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            return View(brand);
        }

        // GET: Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var brand = await _context.Brands.FindAsync(id);
                if (brand == null)
                {
                    return NotFound();
                }
                return View(brand);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Brand brand)
        {
            try
            {
                if (id != brand.Id)
                {
                    return NotFound();
                }
                var data = await _context.Brands.FindAsync(id);
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
                if(brand.Logo != null)
                {
                    if(data != null)
                    {
                        string npath = data.LogoPath.Replace("~", "");
                        string rootpath = wwwRootPath + npath;
                        if(System.IO.File.Exists(rootpath))
                        {
                            System.IO.File.Delete(rootpath);
                        }
                        string extension = Path.GetExtension(brand.Logo.FileName).ToLower();
                        if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == ".svg" || extension == ".gif")
                        {
                            string fileName = brand.Name + extension;
                            //string path = Path.Combine(wwwRootPath, "/Slider", fileName);
                            string path = Path.Combine(fpath, "Pictures", fileName);
                            using (var fileStrem = new FileStream(path, FileMode.Create))
                            {
                                await brand.Logo.CopyToAsync(fileStrem);
                            }
                            brand.LogoPath = "/Slider/Pictures/" + fileName;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Please provide .jpg|.jpeg|.png");
                            return View (brand);
                        }
                    }
                }
                else
                {
                    data.LogoPath = brand.LogoPath;
                }
                data.Id = brand.Id;
                data.Name = brand.Name;
                data.Slug = brand.Slug;
                data.ShortDescription = brand.ShortDescription;
                data.LogoPath = brand.LogoPath;
                data.IsActive = brand.IsActive;

                _context.Update(data);
                if(await _context.SaveChangesAsync() > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(brand);
            }
            

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(brand);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!BrandExists(brand.Id))
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
            return View(brand);
        }

        // GET: Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var brand = await _context.Brands
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (brand == null)
                {
                    return NotFound();
                }

                return View(brand);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                string fpath = "";
                string wwwRootPath = "";
                if(_environment != null)
                {
                    wwwRootPath = _environment.WebRootPath;
                    fpath = wwwRootPath + "/Slider";
                }
                else
                {
                    wwwRootPath = Directory.GetCurrentDirectory();
                    fpath = Path.Combine(wwwRootPath, "/wwwroot/Slider");
                }
                if(_context.Brands == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Brands'  is null.");
                }
                var brands = await _context.Brands.FindAsync(id);
                if(brands != null)
                {
                    string path = brands.LogoPath.Replace("~", "");
                    _context.Brands.Remove(brands);
                    if(await _context.SaveChangesAsync() > 0)
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }


            //var brand = await _context.Brands.FindAsync(id);
            //if (brand != null)
            //{
            //    _context.Brands.Remove(brand);
            //}

            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        private bool BrandExists(int id)
        {
            return _context.Brands.Any(e => e.Id == id);
        }
    }
}
