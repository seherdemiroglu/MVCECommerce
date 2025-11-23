using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCECommerceData;

namespace MVCECommerceWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogsController(MVCECommerceDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()//endpoint:çıkışlar, hdmi gibi
    {
        var items = await dbContext
            .Catalogs
            .Where(p => p.IsEnabled)
            .Select(p => new
            {
                p.Id,
                p.NameEn,
                p.NameTr,
                Products = p.Products.Count(p => p.IsEnabled),
            }).ToListAsync();

        return Ok(items);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)//endpoint
    {
        var item = await dbContext
            .Catalogs
            .Where(p => p.IsEnabled)
            .Select(p => new
            {
                p.Id,
                p.NameEn,
                p.NameTr,
                Products = p.Products.Count(p => p.IsEnabled),
            }).SingleAsync(p => p.Id == id);

        return Ok(item);
    }

    //[HttpPost]
    //public async Task<IActionResult> Post(CatalogDTO model)
    //{


    //    return Ok(items);
    //}

    //[HttpPut("{id:guid}")]
    //public async Task<IActionResult> Put(Guid id, CatalogDTO model)
    //{


    //    return Ok(items);
    //}

    //[HttpDelete("{id:guid}")]
    //public async Task<IActionResult> Delete(Guid id)
    //{


    //    return Ok(items);
    //}
}
