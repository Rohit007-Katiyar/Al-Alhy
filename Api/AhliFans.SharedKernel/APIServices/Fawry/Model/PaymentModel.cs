namespace AhliFans.SharedKernel.APIServices.Fawry.Model;

public class PaymentModel
{
  public string CustomerName { get; set; } = string.Empty;

  public string CustomerMobile { get; set; } = string.Empty;

  public string CustomerEmail { get; set; } = string.Empty;

  public string CardNumber { get; set; } = string.Empty;

  public string CardExpiryYear { get; set; } = string.Empty;

  public string CardExpiryMonth { get; set; } = string.Empty;

  public int Cvv { get; set; }

  public string MerchantRefNum { get; set; } = string.Empty;

  public decimal Amount { get; set; }

  public string Description { get; set; } = string.Empty;

  public string Language { get; set; } = string.Empty;

  public string CustomerProfileId { get; set; } = string.Empty;

  public IReadOnlyList<Item> Items { get; set; } = Array.Empty<Item>();
}

public class Item
{
  public int Id { get; set; }

  public string Description { get; set; } = string.Empty;

  public decimal Price { get; set; }

  public uint Quantity { get; set; }
}
