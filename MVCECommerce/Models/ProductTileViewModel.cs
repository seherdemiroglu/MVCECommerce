namespace MVCECommerce.Models
{
    public class ProductTileViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public Guid? BrandId { get; set; }
        public string? BrandName { get; set; }
    }
}
