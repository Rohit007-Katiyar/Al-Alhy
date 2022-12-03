namespace AhliFans.SharedKernel.APIServices.Fawry.Settings;

public class FawrySettings
{
  public string MerchantCode { get; set; } = string.Empty;

  public bool Enable3ds { get; set; }

  public string SecureKey { get; set; } = string.Empty;

  public string PaymentUrl { get; set; } = string.Empty;
}
