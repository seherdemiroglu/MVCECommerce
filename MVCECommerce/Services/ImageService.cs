namespace MVCECommerce.Services
{
    public class ImageService : IImageService
    {
        public async Task<byte[]> ProcessWebpImageAsync(IFormFile file, int width, int height)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Resim dosyası boş.");

            using var image = await Image.LoadAsync(file.OpenReadStream());
            image.Mutate(x => x.Resize(new ResizeOptions
            {
                Size = new Size(width, height),
                Mode = ResizeMode.Crop
            }));

            using var ms = new MemoryStream();
            await image.SaveAsWebpAsync(ms); // WebP formatında sıkıştır
            return ms.ToArray();
        }
    }
}
