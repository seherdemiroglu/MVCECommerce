using System.ComponentModel.DataAnnotations;

namespace MVCECommerce.Areas.Admin.Models
{
    public class CarouselImageDto
    {
        public Guid Id { get; set; }

        [Display(Name = "Url")]
        public string? Url { get; set; }
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Aktif")]
        public bool IsEnabled { get; set; }

        [Display(Name = "Katalog")]
        public Guid? CatalogId { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
