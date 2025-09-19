namespace MVCECommerce.Models;

public class PaymentViewModel
{
    public Guid ShippingAddressId { get; set; }
    public Guid BillingAddressId { get; set; }

    public string? CardNumber { get; set; }
    public string? CardHolderName { get; set; }
    public string? Cvc { get; set; }
    public int ExpireMonth { get; set; }
    public int ExpireYear { get; set; }
}
