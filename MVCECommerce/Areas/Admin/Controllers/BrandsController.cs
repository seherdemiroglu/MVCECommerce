using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCECommerce.Domain;

namespace MVCECommerce.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Administrators,ProductAdministrators")]
public class BrandsController(MVCECommerceDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var items = await dbContext.Brands.OrderBy(p => p.Name).ToListAsync();
        return View(items);
    }
    public IActionResult Create()
    {
        return View(new Brand { });//data transfer object yapmadık, IsEnabled otomatik true gittiği için forma da tikli gitsin diye forma Category objesi oluşturup gönderdik
    }

    [HttpPost]
    public async Task<IActionResult> Create(Brand model)
    {
        model.CreatedAt = DateTime.UtcNow;

        if(model.LogoFile is not null)
        {
            using var image =await Image.LoadAsync(model.LogoFile.OpenReadStream());
            image.Mutate(p =>
            {
                p.Resize(new ResizeOptions
                {
                    Size=new Size(180,180),
                    Mode=ResizeMode.Max
                });
            });
            using var ms=new MemoryStream();
            await image.SaveAsWebpAsync(ms);
            model.Logo=ms.ToArray();
        }

        dbContext.Add(model);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var item = await dbContext.Brands.SingleOrDefaultAsync(p => p.Id == id);
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Brand model)
    {
        var item = await dbContext.Brands.SingleOrDefaultAsync(p => p.Id == model.Id);
        item.Name = model.Name;
      
        item.IsEnabled = model.IsEnabled;

        if (model.LogoFile is not null)
        {
            using var image = await Image.LoadAsync(model.LogoFile.OpenReadStream());
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
            item.Logo = ms.ToArray();
        }

        dbContext.Update(item);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var item = await dbContext.Brands.SingleOrDefaultAsync(p => p.Id == id);
        dbContext.Remove(item);
        await dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
