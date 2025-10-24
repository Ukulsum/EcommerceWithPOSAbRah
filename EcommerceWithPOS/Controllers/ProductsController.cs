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
    public class ProductsController : Controller
    {
        private readonly EcommerceDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private static int _nextId = 1;

        public ProductsController(EcommerceDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            try
            {
                var ecommerceDbContext = _context.Products.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).Include(p => p.Tax).Include(p => p.Unit);
                return View(await ecommerceDbContext.ToListAsync());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }            
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Color)
                .Include(p => p.Size)
                .Include(p => p.Tax)
                .Include(p => p.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
                if (product == null)
                {
                    return NotFound();
                }

                return View(product);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            if (id == null)
            {
                return NotFound();
            }  
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name");
                ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
                ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name");
                ViewData["SizeId"] = new SelectList(_context.PSizes, "Id", "Name");
                ViewData["TaxId"] = new SelectList(_context.Taxs, "Id", "Name");
                ViewData["UnitId"] = new SelectList(_context.Units, "Id", "UnitName");
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(product.ProductPicture != null)
                    {
                        int result = 0;
                        try
                        {
                            for(int i = 0; i < product.ProductPicture.Count; i++)
                            {
                                string ext = Path.GetExtension(product.ProductPicture[i].FileName).ToLower();
                                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                                {
                                    string savePath = Path.Combine(_environment.WebRootPath, "Pictures");
                                    if (!Directory.Exists(savePath))
                                    {
                                        Directory.CreateDirectory(savePath);
                                    }
                                    int count = i + 1;

                                    string filePath = Path.Combine(savePath, product.ProductName + "_" + count + ext);
                                    using(FileStream fs = new FileStream(filePath, FileMode.Create))
                                    {
                                        product.ProductPicture[i].CopyTo(fs);
                                    }
                                    if(i == 0)
                                    {
                                        product.PicturePath = "Pictures" + product.ProductName + "_" + count + ext;
                                    }

                                    product.ProductImages.Add(new ProductImage
                                    {
                                        ImagePath = "/Pictures/" + product.ProductName + "_" + count + ext,
                                    });
                                }
                                else
                                {
                                    ModelState.AddModelError("", "Please enter valid image");
                                }

                                //foreach (var color in Color)

                                //product.GenerateSku();
                                _context.Products.Add(product);
                                result = await _context.SaveChangesAsync();
                                if(result > 0)
                                {
                                    return RedirectToAction("Index");
                                }
                                else
                                {
                                    ModelState.AddModelError("", "Save failed");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError("", ex.Message);
                        }
                    }
                    
                }
                else
                {
                    var message = string.Join(" | ", ModelState.Values
                                     .SelectMany(v => v.Errors)
                                     .Select(e => e.ErrorMessage));
                    ModelState.AddModelError("", message);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            //if (ModelState.IsValid)
            //{
            //    _context.Add(product);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", product.BrandId);
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            //ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name", product.ColorId);
            //ViewData["SizeId"] = new SelectList(_context.PSizes, "Id", "Name", product.SizeId);
            //ViewData["TaxId"] = new SelectList(_context.Taxs, "Id", "Id", product.TaxId);
            //ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id", product.UnitId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name", product.ColorId);
            ViewData["SizeId"] = new SelectList(_context.PSizes, "Id", "Name", product.SizeId);
            ViewData["TaxId"] = new SelectList(_context.Taxs, "Id", "Id", product.TaxId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id", product.UnitId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Slug,Code,Sku,Tags,Description,ShortDescription,Specification,PicturePath,CategoryId,UnitId,BrandId,TaxId,PurchasePrice,RetailPrice,WholeSalePrice,Quantity,DiscountRate,DiscountAmount,IsActive,IsVariant,ColorId,SizeId,TaxMethod,CreatedAt,UpdatedAt")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name", product.ColorId);
            ViewData["SizeId"] = new SelectList(_context.PSizes, "Id", "Name", product.SizeId);
            ViewData["TaxId"] = new SelectList(_context.Taxs, "Id", "Id", product.TaxId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id", product.UnitId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Color)
                .Include(p => p.Size)
                .Include(p => p.Tax)
                .Include(p => p.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
