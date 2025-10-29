using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcommerceWithPOS.Data;
using EcommerceWithPOS.Models;
using System.Drawing;

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
                var ecommerceDbContext = _context.Products.Include(p => p.Brand).Include(p => p.Category)
                    //.Include(p => p.Color)
                    //.Include(p => p.Size)
                    .Include(p => p.Tax).Include(p => p.Unit);
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
                //.Include(p => p.Color)
                //.Include(p => p.Size)
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

        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, string[] Colors, string[] Sizes, string[] Quantities)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                                     .SelectMany(v => v.Errors)
                                     .Select(e => e.ErrorMessage));
                ModelState.AddModelError("", message);
                return View(product);
            }

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Save images
                if (product.ProductPicture != null && product.ProductPicture.Count > 0)
                {
                    string savePath = Path.Combine(_environment.WebRootPath, "Pictures");
                    if (!Directory.Exists(savePath))
                        Directory.CreateDirectory(savePath);

                    for (int i = 0; i < product.ProductPicture.Count; i++)
                    {
                        var file = product.ProductPicture[i];
                        string ext = Path.GetExtension(file.FileName).ToLower();
                        if (ext != ".jpg" && ext != ".jpeg" && ext != ".png")
                        {
                            ModelState.AddModelError("", "Only JPG, JPEG, PNG allowed.");
                            return View(product);
                        }

                        string fileName = $"{product.ProductName}_{i + 1}{ext}";
                        string filePath = Path.Combine(savePath, fileName);

                        using (var fs = new FileStream(filePath, FileMode.Create))
                            await file.CopyToAsync(fs);

                        if (i == 0)
                            product.PicturePath = "/Pictures/" + fileName;

                        product.ProductImages.Add(new ProductImage { ImagePath = "/Pictures/" + fileName });
                    }
                }

                //string shortName = new string(product.ProductName.Where(char.IsLetterOrDigit).ToArray()).ToUpper();
                //if (shortName.Length > 4)
                //    shortName = shortName.Substring(0, 4);

                //// Generate Serial Number (based on last Id)
                //int nextId = (_context.Products.Any() ? _context.Products.Max(p=>p.Id) : 0) + 1;
                //string serial = nextId.ToString("00000");

                //// final product code formate : Prd-shirt-00001
                //product.Code = $"prd-{shortName}-{serial}";

                // 2. Save Product first to generate Id
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                // 3. Save Colors and Sizes
                if (Colors != null && Sizes != null && Quantities != null)
                {
                    int len = Math.Min(Colors.Length, Math.Min(Sizes.Length, Quantities.Length));

                    for (int i = 0; i < len; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(Colors[i]))
                        {
                            var color = new ProductColor
                            {
                                ProductId = product.Id,
                                Name = Colors[i].Trim(),
                                Sizes = new List<PSize>()
                            };

                            var sizeArr = Sizes[i].Split(',', StringSplitOptions.RemoveEmptyEntries);
                            var qtyArr = Quantities[i].Split(',', StringSplitOptions.RemoveEmptyEntries);

                            for (int j = 0; j < Math.Min(sizeArr.Length, qtyArr.Length); j++)
                            {
                                if (int.TryParse(qtyArr[j].Trim(), out int qty))
                                {
                                    color.Sizes.Add(new PSize
                                    {
                                        Name = sizeArr[j].Trim(),
                                        Quantity = qty
                                    });
                                }
                               
                            }
                            _context.Colors.Add(color);
                        }
                    }
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                ModelState.AddModelError("", ex.Message);
                return View(product);
            }
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
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name");
            ViewData["SizeId"] = new SelectList(_context.PSizes, "Id", "Name");
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
            //ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name", product.ColorId);
            //ViewData["SizeId"] = new SelectList(_context.PSizes, "Id", "Name", product.SizeId);
            ViewData["TaxId"] = new SelectList(_context.Taxs, "Id", "Id", product.TaxId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id", product.UnitId);
            return View(product);
        }






        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Slug,Code,Sku,Tags,Description,ShortDescription,Specification,PicturePath,CategoryId,UnitId,BrandId,TaxId,PurchasePrice,RetailPrice,WholeSalePrice,Quantity,DiscountRate,DiscountAmount,IsActive,IsVariant,ColorId,SizeId,TaxMethod,CreatedAt,UpdatedAt")] Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(product);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(product.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", product.BrandId);
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
        //    //ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name", product.ColorId);
        //    //ViewData["SizeId"] = new SelectList(_context.PSizes, "Id", "Name", product.SizeId);
        //    ViewData["TaxId"] = new SelectList(_context.Taxs, "Id", "Id", product.TaxId);
        //    ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id", product.UnitId);
        //    return View(product);
        //}

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
                //.Include(p => p.Color)
                //.Include(p => p.Size)
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
