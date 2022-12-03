using Newtonsoft.Json;

namespace AhliFans.SharedKernel.APIServices.Cequens.Model;

public class SendOtpRequest
{
  [JsonProperty("channel")] public string Channel { get; set; } = string.Empty;

  [JsonProperty("recipientIdentifier")] public string RecipientIdentifier { get; set; } = string.Empty;

  [JsonProperty("templateCode")] public string? TemplateCode { get; set; }

  [JsonProperty("otpCodeLength")] public string? OtpCodeLength { get; set; }

  [JsonProperty("otpCodeExpiry")] public string? OtpCodeExpiry { get; set; }

  [JsonProperty("wabTemplateName")] public string? WabTemplateName { get; set; }

  [JsonProperty("wabTemplateLanguage")] public string? WabTemplateLanguage { get; set; }
}

public class SendOtpResponse : ISendOtpResult
{
  [JsonProperty("status")] public int Status { get; set; }

  [JsonProperty("replyMessage")] public string ReplyMessage { get; set; } = string.Empty;

  [JsonProperty("requestId")] public string RequestId { get; set; } = string.Empty;

  [JsonProperty("requestTime")] public string RequestTime { get; set; } = string.Empty;

  [JsonProperty("data")] public ResponseData Data { get; set; } = new();

  public string ErrorMessage => string.Empty;

  public bool IsSuccessful => true;

  public string CheckCode => Data.CheckCode;
}

public class ResponseData
{
  [JsonProperty("checkCode")] public string CheckCode { get; set; } = string.Empty;
}

public class Obj
{
}

public class SendOtpBadRequestResponse : ISendOtpResult
{
  [JsonProperty("status")]
  public int Status { get; set; }

  [JsonProperty("requestId")]
  public string RequestId { get; set; } = string.Empty;

  [JsonProperty("clientRequestId")]
  public int ClientRequestId { get; set; }

  [JsonProperty("replyCode")]
  public int ReplyCode { get; set; }

  [JsonProperty("requestTime")]
  public DateTime RequestTime { get; set; }

  [JsonProperty("replyMessage")]
  public string ReplyMessage { get; set; } = string.Empty;

  [JsonProperty("data")]
  public Obj Data { get; set; } = new();

  [JsonProperty("error")]
  public string Error { get; set; } = string.Empty;

  public string ErrorMessage => Error;

  public bool IsSuccessful => false;

  public string CheckCode => string.Empty;
}

public class SendOTPFailure : ISendOtpResult
{
  private const string Error = "Something went wrong with the request, please try again later";
  public string ErrorMessage => Error;

  public bool IsSuccessful => false;

  public string CheckCode => string.Empty;
}