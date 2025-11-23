using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCECommerceData;

namespace MVCECommerceWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(MVCECommerceDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var items = await dbContext.Categories
            .Where(p => p.IsEnabled)
            .Select(p => new
            {
                p.Id,
                p.NameEn,
                p.NameTr,
                Products = p.Products.Count(p => p.IsEnabled)
            }).ToListAsync();

        return Ok(items);

    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var item = await dbContext.Categories
            .Where(p => p.IsEnabled)
            .Select(p => new
            {
                p.Id,
                p.NameEn,
                p.NameTr,
                Products = p.Products.Count(p => p.IsEnabled)
            }).SingleAsync(p=>p.Id==id);

        return Ok(item);
    }
}
