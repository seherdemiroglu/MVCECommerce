using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCECommerce.Models;
using System.Text.RegularExpressions;

namespace MVCECommerce.Controllers
{
    public class HomeController(MVCECommerceDbContext dbContext) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Search(string keyword)
        {
            var keywords = Regex.Split(keyword, @"\s+");
            var model = (await dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .ToListAsync())
                .Where(p => keyword.Any(q => p.NameEn!.Contains(q) || p.NameTr!.Contains(q)))
                .Select(p => new ProductTileViewModel
                {
                    BrandId = p.BrandId,
                    BrandName = p.Brand?.Name,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category?.NameEn,
                    Name = p.NameEn,
                    Id = p.Id,
                    Price = p.Price
                });
            return View(model);
        }

        public async Task<IActionResult> Category(Guid id)
        {
            var model = await dbContext
                .Categories
                .Include(p => p.Products)
                .SingleOrDefaultAsync(p => p.Id == id);
            return View(model);
        }
        public async Task<IActionResult> Catalog(Guid id)
        {
            var model = await dbContext
                .Catalogs
                .Include(p => p.Products).ThenInclude(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
            return View(model);
        }
        public async Task<IActionResult> Brand(Guid id)
        {
            var model = await dbContext
                .Brands
                .Include(p => p.Products).ThenInclude(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
            return View(model);
        }
        public async Task<IActionResult> Detail(Guid id)
        {
            var model = await dbContext
                .Products
                .Include(p => p.Category)
                .Include(p => p.Specs).ThenInclude(p => p.Specification)
                .Include(p => p.Catalogs)
                .Include(p => p.ProductImages)
                .Include(p => p.Brand)
                .Include(p => p.Comments).ThenInclude(p=>p.User)
                .SingleOrDefaultAsync(p => p.Id == id);
            return View(model);
        }
    }


}
