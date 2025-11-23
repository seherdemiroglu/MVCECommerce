using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCECommerceData;

namespace MVCECommerce.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Administrators,ProductAdministrators")]
public class CatalogsController(MVCECommerceDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var items = await dbContext.Catalogs.OrderBy(p => p.NameTr).ToListAsync();
        return View(items);
    }
    public IActionResult Create()
    {
        return View(new Catalog { });//data transfer object yapmadık, IsEnabled otomatik true gittiği için forma da tikli gitsin diye forma Category objesi oluşturup gönderdik
    }

    [HttpPost]
    public async Task<IActionResult> Create(Catalog model)
    {

        model.CreatedAt = DateTime.UtcNow;
        dbContext.Add(model);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var item = await dbContext.Catalogs.SingleOrDefaultAsync(p => p.Id == id);
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Catalog model)
    {
        var item = await dbContext.Catalogs.SingleOrDefaultAsync(p => p.Id == model.Id);
        item.NameTr = model.NameTr;
        item.NameEn = model.NameEn;
        item.IsEnabled = model.IsEnabled;

        dbContext.Update(item);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var item = await dbContext.Catalogs.SingleOrDefaultAsync(p => p.Id == id);
        dbContext.Remove(item);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
