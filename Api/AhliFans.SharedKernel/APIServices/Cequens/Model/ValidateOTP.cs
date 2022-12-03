using Newtonsoft.Json;

namespace AhliFans.SharedKernel.APIServices.Cequens.Model;

public class ValidateOtpRequest
{
  [JsonProperty("otpPasscode")] public string OtpPasscode { get; set; } = string.Empty;

  [JsonProperty("checkCode")] public string CheckCode { get; set; } = string.Empty;
}

public class ValidateOtpResponse
{
  [JsonProperty("requestId")] public string RequestId { get; set; } = string.Empty;
  [JsonProperty("status")] public int Status { get; set; }

  [JsonProperty("replyMessage")] public string ReplyMessage { get; set; } = string.Empty;

  [JsonProperty("replyCode")] public int ReplyCode { get; set; } 

  [JsonProperty("requestTime")] public string RequestTime { get; set; } = string.Empty;

  [JsonProperty("data")] public ValidateOtpResponseData Data { get; set; } = new();

}

public class ValidateOtpResponseData
{
  [JsonProperty("otpPasscodeStatus")] public int otpPasscodeStatus { get; set; }
}

public class Data
{
}

public class ValidateOtpErrorResponse
{
  [JsonProperty("status")]
  public int Status { get; set; }

  [JsonProperty("replyMessage")]
  public string ReplyMessage { get; set; } = string.Empty;

  [JsonProperty("requestId")]
  public string RequestId { get; set; } = string.Empty;

  [JsonProperty("requestTime")]
  public DateTime RequestTime { get; set; }

  [JsonProperty("data")]
  public CheckData Data { get; set; } = new();

  [JsonProperty("error")]
  public string Error { get; set; } = string.Empty;
}
