namespace MVCECommerce.Services
{
    public interface IImageService
    {
        Task<byte[]> ProcessWebpImageAsync(IFormFile file, int width, int height);
    }
}
