using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCECommerceData;

namespace MVCECommerceWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(MVCECommerceDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var items=await dbContext.Products
            .Where(p=>p.IsEnabled)
            .Select(p=> new
            {
                p.Id,
                p.NameEn,
                p.NameTr,
                p.Price,
                p.DescriptionEn,
                p.DescriptionTr,
                Comments = p.Comments.Count(),
                Rating = p.Comments.Any() ? p.Comments.Average(q => q.Score) : 0,
                ImageUrl = $"https://localhost:7137/Images/Product/{p.Id}",
                Images = p.ProductImages.Select(q => $"https://localhost:7137/Images/ProductImage/{q.Id}").ToList()

            }).ToListAsync();

        return Ok(items);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var item = await dbContext.Products
            .Where(p => p.IsEnabled)
            .Select(p => new
            {
                p.Id,
                p.NameEn,
                p.NameTr,
                p.Price,
                p.DescriptionEn,
                p.DescriptionTr,
                Comments = p.Comments.Count(),
                Rating = p.Comments.Any() ? p.Comments.Average(q => q.Score) : 0,
                ImageUrl = $"https://localhost:7137/Images/Product/{p.Id}",
                Images = p.ProductImages.Select(q => $"https://localhost:7137/Images/ProductImage/{q.Id}").ToList()

            }).SingleAsync(p => p.Id == id);

        return Ok(item);
    }

    //[HttpGet("{id:guid}")]
    //public async Task<IActionResult> Get(Guid id)
    //{
    //    var item = await dbContext.Products
    //        .Where(p => p.IsEnabled && p.Id==id)
    //        .Select(p => new
    //        {
    //            p.Id,
    //            p.NameEn,
    //            p.NameTr,
    //            p.Price,
    //            p.DescriptionEn,
    //            p.DescriptionTr,
    //            Comments = p.Comments.Count(),
    //            Rating = p.Comments.Any() ? p.Comments.Average(q => q.Score) : 0,
    //            ImageUrl = $"https://localhost:7137/Images/Product/{p.Id}",
    //            Images = p.ProductImages.Select(q => $"https://localhost:7137/Images/ProductImage/{q.Id}").ToList()

    //        }).SingleAsync();

    //    return Ok(item);
    //}
}
