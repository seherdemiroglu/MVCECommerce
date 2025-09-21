namespace MVCECommerce.Models;

public class CommentViewModel
{
    public Guid ProductId { get; set; }
    public string? ProductName { get; set; }
    public string? Text { get; set; }
    public int Rating { get; set; }
}
