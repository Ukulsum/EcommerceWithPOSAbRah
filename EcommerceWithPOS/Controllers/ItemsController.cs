using EcommerceWithPOS.Data;
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
    public class ItemsController : Controller
    {
        private readonly EcommerceDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ItemsController(EcommerceDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var ecommerceDbContext = _context.Items.Include(i => i.Brand).Include(i => i.Category).Include(i => i.Tax).Include(i => i.Unit);
            return View(await ecommerceDbContext.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Brand)
                .Include(i => i.Category)
                .Include(i => i.Tax)
                .Include(i => i.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["TaxId"] = new SelectList(_context.Taxs, "Id", "Id");
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Item product, string[] colors, string[] sizes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (product.ProductPicture != null)
                    {
                        //product.Sku = product.GenerateSku();
                        //product.Id = _nextId++;
                        //product.GenerateSku();
                        //product.Sku = GenerateSku(product.Brand, product.Id == 0 ? new Random().Next(10000, 99999) : product.Id, product.Size, product.Color);
                        int result = 0;
                        try
                        {
                            for (int i = 0; i < product.ProductPicture.Count; i++)
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

                                    string filePath = Path.Combine(savePath, product.ItemName + "_" + count + ext);
                                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                                    {
                                        product.ProductPicture[i].CopyTo(fs);
                                    }
                                    if (i == 0)
                                    {
                                        product.PicturePath = "Pictures" + product.ItemName + "_" + count + ext;
                                    }

                                    product.ProductImages.Add(new ProductImage
                                    {
                                        ImagePath = "/Pictures/" + product.ItemName + "_" + count + ext,
                                    });
                                }
                                else
                                {
                                    ModelState.AddModelError("", "Please enter valid image");
                                }

                                //foreach(var color in colors)
                                //{
                                //    foreach(var size in sizes)
                                //    {
                                //        var variant = new ProductVariant
                                //        {
                                //            ItemId = product.Id,

                                //        }
                                //    }
                                //}


                                //product.GenerateSku();
                                _context.Items.Add(product);
                                result = await _context.SaveChangesAsync();
                                if (result > 0)
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
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            return View(product);
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,ItemName,Slug,Tags,Description,PicturePath,CategoryId,UnitId,BrandId,TaxId,PurchasePrice,RetailPrice,WholeSalePrice,Quantity,DiscountRate,DiscountAmount,IsActive,TaxMethod,CreatedAt,UpdatedAt")] Item item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(item);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", item.BrandId);
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", item.CategoryId);
        //    ViewData["TaxId"] = new SelectList(_context.Taxs, "Id", "Id", item.TaxId);
        //    ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id", item.UnitId);
        //    return View(item);
        //}

        // Variant CRUD

        //[HttpPost]
        //public IActionResult AddVariant(int productId, string color, string size, int stock)
        //{
        //    var product = _context.FirstOrDefault(p => p.Id == productId);
        //    if (product != null)
        //    {
        //        var variant = new ProductVariant
        //        {
        //            Id = product.Variants.Count + 1,
        //            ProductId = productId,
        //            Product = product,
        //            Color = color,
        //            Size = size,
        //            Stock = stock
        //        };
        //        variant.GenerateSku();
        //        product.Variants.Add(variant);
        //    }
        //    return RedirectToAction("Edit", new { id = productId });
        //}

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", item.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", item.CategoryId);
            ViewData["TaxId"] = new SelectList(_context.Taxs, "Id", "Id", item.TaxId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id", item.UnitId);
            return View(item);
        }

        


        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemName,Slug,Tags,Description,PicturePath,CategoryId,UnitId,BrandId,TaxId,PurchasePrice,RetailPrice,WholeSalePrice,Quantity,DiscountRate,DiscountAmount,IsActive,TaxMethod,CreatedAt,UpdatedAt")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", item.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", item.CategoryId);
            ViewData["TaxId"] = new SelectList(_context.Taxs, "Id", "Id", item.TaxId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id", item.UnitId);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Brand)
                .Include(i => i.Category)
                .Include(i => i.Tax)
                .Include(i => i.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
