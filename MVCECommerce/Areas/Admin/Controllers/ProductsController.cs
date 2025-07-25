using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCECommerce.Domain;

namespace MVCECommerce.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Administrators,ProductAdministrators")]
public class ProductsController(MVCECommerceDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var items = await dbContext.Products.OrderBy(p => p.NameTr).ToListAsync();
        return View(items);
    }
    public IActionResult Create()
    {
        return View(new Product { });
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product model)
    {
        model.CreatedAt = DateTime.UtcNow;

        if(model.ImageFile is not null)
        {
            using var image =await Image.LoadAsync(model.ImageFile.OpenReadStream());
            image.Mutate(p =>
            {
                p.Resize(new ResizeOptions
                {
                    Size=new Size(800,600),
                    Mode=ResizeMode.BoxPad
                });
            });
            using var ms=new MemoryStream();
            await image.SaveAsWebpAsync(ms);
            model.Image=ms.ToArray();
        }

        if(model.SelectedCatalogs is not null)
        {
            
            model.SelectedCatalogs.ToList().ForEach(p=>model.Catalogs.Add(dbContext.Catalogs.Find(p)!));
            
        }

        dbContext.Add(model);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var item = await dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product model)
    {
        var item = await dbContext.Products.SingleOrDefaultAsync(p => p.Id == model.Id);
        item.NameTr = model.NameTr;
        item.NameEn = model.NameEn;

        item.IsEnabled = model.IsEnabled;

        if (model.ImageFile is not null)
        {
            using var image = await Image.LoadAsync(model.ImageFile.OpenReadStream());
            image.Mutate(p =>
            {
                p.Resize(new ResizeOptions
                {
                    Size = new Size(180, 180),
                    Mode = ResizeMode.Max
                });
            });
            using var ms = new MemoryStream();
            await image.SaveAsWebpAsync(ms);
            item.Image = ms.ToArray();
        }

        dbContext.Update(item);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var item = await dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
        dbContext.Remove(item);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
