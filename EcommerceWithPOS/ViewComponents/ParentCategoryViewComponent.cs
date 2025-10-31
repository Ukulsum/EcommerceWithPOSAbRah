using EcommerceWithPOS.Data;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWithPOS.ViewComponents
{
    public class ParentCategoryViewComponent : ViewComponent
    {
        private readonly EcommerceDbContext _context;
        public ParentCategoryViewComponent(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var data = _context.Categories.ToList();
                return View(data);
            }
            catch (Exception ex)
            {
                throw new Exception("ParentCategoryViewComponent error: " + ex.Message, ex);
            }
        }
    }
}
