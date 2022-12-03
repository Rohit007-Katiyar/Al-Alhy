namespace AhliFans.SharedKernel.APIServices.Fawry.Model;

public class CardModel
{
  public string UserId { get; set; } = string.Empty;

  public string UserMobile { get; set; } = string.Empty;

  public string UserEmail { get; set; } = string.Empty;

  public bool IsDefault { get; set; }

  public string CardNumber { get; set; } = string.Empty;

  public string CardAlias { get; set; } = string.Empty;

  public string ExpiryYear { get; set; } = string.Empty;

  public string ExpiryMonth { get; set; } = string.Empty;

  public int Cvv { get; set; }
}
