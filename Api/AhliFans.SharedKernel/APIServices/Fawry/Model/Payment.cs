using AhliFans.SharedKernel.APIServices.Fawry.Constants;
using Newtonsoft.Json;

namespace AhliFans.SharedKernel.APIServices.Fawry.Model;
public class PaymentRequest
{
  [JsonProperty("merchantCode")] public string MerchantCode { get; set; } = string.Empty;

  [JsonProperty("customerName")] public string CustomerName { get; set; } = string.Empty;

  [JsonProperty("customerMobile")] public string CustomerMobile { get; set; } = string.Empty;

  [JsonProperty("customerEmail")] public string CustomerEmail { get; set; } = string.Empty;

  [JsonProperty("customerProfileId")] public string CustomerProfileId { get; set; } = string.Empty;

  [JsonProperty("cardNumber")] public string CardNumber { get; set; } = string.Empty;

  [JsonProperty("cardExpiryYear")] public string CardExpiryYear { get; set; } = string.Empty;

  [JsonProperty("cardExpiryMonth")] public string CardExpiryMonth { get; set; } = string.Empty;

  [JsonProperty("cvv")] public string Cvv { get; set; } = string.Empty;

  [JsonProperty("merchantRefNum")] public string MerchantRefNum { get; set; } = string.Empty;

  [JsonProperty("amount")]
  public decimal Amount { get; set; }

  [JsonProperty("currencyCode")] public string CurrencyCode { get; set; } = string.Empty;

  [JsonProperty("language")] public string Language { get; set; } = string.Empty;

  [JsonProperty("chargeItems")] public IEnumerable<ChargeItem> ChargeItems { get; set; } = Array.Empty<ChargeItem>();

  [JsonProperty("signature")] public string Signature { get; set; } = string.Empty;

  [JsonProperty("paymentMethod")] public string PaymentMethod { get; set; } = string.Empty;

  [JsonProperty("description")] public string Description { get; set; } = string.Empty;
}

public class ChargeItem
{
  [JsonProperty("itemId")] public string ItemId { get; set; } = string.Empty;

  [JsonProperty("description")] public string Description { get; set; } = string.Empty;

  [JsonProperty("price")]
  public decimal Price { get; set; }

  [JsonProperty("quantity")] public uint Quantity { get; set; } 
}

public class PaymentResponse : IPaymentResult
{
  [JsonProperty("type")] public string Type { get; set; } = string.Empty;

  [JsonProperty("referenceNumber")] public string ReferenceNumber { get; set; } = string.Empty;

  [JsonProperty("merchantRefNumber")] public string MerchantRefNumber { get; set; } = string.Empty;

  [JsonProperty("orderAmount")]
  public decimal OrderAmount { get; set; }

  [JsonProperty("paymentAmount")]
  public decimal PaymentAmount { get; set; }

  [JsonProperty("fawryFees")]
  public decimal FawryFees { get; set; }

  [JsonProperty("paymentMethod")] public string PaymentMethod { get; set; } = string.Empty;

  [JsonProperty("orderStatus")] public string OrderStatus { get; set; } = string.Empty;

  [JsonProperty("paymentTime")]
  public long PaymentTime { get; set; }

  [JsonProperty("customerMobile")] public string CustomerMobile { get; set; } = string.Empty;

  [JsonProperty("customerMail")] public string CustomerMail { get; set; } = string.Empty;

  [JsonProperty("authNumber")] public string AuthNumber { get; set; } = string.Empty;

  [JsonProperty("customerProfileId")] public string CustomerProfileId { get; set; } = string.Empty;

  [JsonProperty("signature")] public string Signature { get; set; } = string.Empty;

  [JsonProperty("statusCode")]
  public int StatusCode { get; set; }

  [JsonProperty("statusDescription")] public string StatusDescription { get; set; } = string.Empty;

  public string ErrorMessage => IsSuccessful ? string.Empty : StatusDescription;

  public bool IsSuccessful => StatusCode == 200;

  public PaymentStatus Status => System.Enum.TryParse<PaymentStatus>(OrderStatus, true, out var status) ? status : PaymentStatus.FAILED;
}


