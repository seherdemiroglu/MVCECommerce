using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MVCECommerce.Controllers;

public class ApiController(MVCECommerceDbContext dbContext) : Controller
{
    public async Task<IActionResult> GetCities(int id)
    {
        var model = await dbContext
            .Cities
            .Where(p => p.ProvinceId == id)
            .OrderBy(p => p.Name)
            .Select(p => new { p.Id, p.Name })
            .ToListAsync();
        return Json(model);
    }
}
