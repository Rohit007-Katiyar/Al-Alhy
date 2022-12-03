namespace AhliFans.SharedKernel.APIServices.Fawry.Constants;

public static class PaymentConstants
{
  public const string Arabic = "ar-eg";

  public const string English = "en-gb";

  public const string EgyptianCurrency = "EGP";
}

public enum PaymentMethods
{
  CARD,
  PAYATFAWRY,
  CASHONDELIVERY,
  MWALLET
}

public enum PaymentStatus
{
  PAID,
  NEW,
  CANCELED,
  DELIVERED,
  REFUNDED,
  EXPIRED,
  PARTIAL_REFUNDED,
  FAILED,
  PENDING
}

