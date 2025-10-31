using EcommerceWithPOS.Data;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWithPOS.ViewComponents
{
    public class SubCategoryViewComponent : ViewComponent
    {
        private readonly EcommerceDbContext _context;
        public SubCategoryViewComponent(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int cid)
        {
            var data = _context.Categories.Where(m => m.Id == cid).ToList();
            ViewBag.ParentId = _context.Categories.Where(t => t.ParentId != 0).Select(p => p.ParentId).ToList(); 
            return View(data);
        }
    }
}
