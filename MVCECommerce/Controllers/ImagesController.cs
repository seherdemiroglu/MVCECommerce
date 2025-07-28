using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Threading.Tasks;

namespace MVCECommerce.Areas.Admin.Controllers
{
    public class ImagesController(MVCECommerceDbContext dbContext) : Controller
    {

        [OutputCache(Duration =86400)]
        public async Task<IActionResult> Brand(Guid id)
        {
            var item=await dbContext.Brands.FindAsync(id);

            return File(item.Logo,"image/webp");
        }

        [OutputCache(Duration = 86400)]
        public async Task<IActionResult> Product(Guid id)
        {
            var item = await dbContext.Products.FindAsync(id);
            return File(item.Image, "image/webp");
        }

        [OutputCache(Duration = 86400)]
        public async Task<IActionResult> CarouselImage(Guid id)
        {
            var item = await dbContext.CarouselImages.FindAsync(id);
            return File(item.Image, "image/webp");
        }
    }
}
