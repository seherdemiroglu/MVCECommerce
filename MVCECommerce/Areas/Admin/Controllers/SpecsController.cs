using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCECommerce.Domain;

namespace MVCECommerce.Areas.Admin.Controllers  
{
    [Area("Admin")]
    [Authorize(Roles = "Administrators,ProductAdministrators")]
    public class SpecsController(MVCECommerceDbContext dbContext) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var items = await dbContext
            .Categories
            .Include(p => p.Specifications)
            .AsSplitQuery()
            .AsNoTracking()
            .OrderBy(p => p.NameTr)
            .ToListAsync();
            return View(items);
        }
        public IActionResult Create()
        {
            return View(new Specification { });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Specification model)
        {

            model.CreatedAt = DateTime.UtcNow;

            dbContext.Add(model);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var item = await dbContext.Specifications.SingleOrDefaultAsync(p => p.Id == id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Specification model)
        {
            var item = await dbContext.Specifications.SingleOrDefaultAsync(p => p.Id == model.Id);
            item.NameTr = model.NameTr;
            item.NameEn = model.NameEn;
            item.IsEnabled = model.IsEnabled;

            dbContext.Update(item);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await dbContext.Specifications.SingleOrDefaultAsync(p => p.Id == id);
            dbContext.Remove(item);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
