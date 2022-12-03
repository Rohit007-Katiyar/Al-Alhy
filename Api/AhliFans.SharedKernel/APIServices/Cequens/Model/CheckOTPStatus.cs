using Newtonsoft.Json;

namespace AhliFans.SharedKernel.APIServices.Cequens.Model;

public class ChecksList
{
  [JsonProperty("otpStatus")] public int OtpStatus { get; set; }
  [JsonProperty("verificationDate")] public DateTime VerificationDate { get; set; }
  [JsonProperty("verificationStatus")] public bool VerificationStatus { get; set; }
}

public class CheckData
{
  [JsonProperty("recipientIdentifier")] public string RecipientIdentifier { get; set; } = string.Empty;
  [JsonProperty("sendDate")] public DateTime SendDate { get; set; }
  [JsonProperty("channel")] public string Channel { get; set; } = string.Empty;
  [JsonProperty("otpExpiryMinutes")] public int OtpExpiryMinutes { get; set; }
  [JsonProperty("ChecksList")] public IReadOnlyList<ChecksList> ChecksList { get; set; } = Array.Empty<ChecksList>();
}

public class CheckOtpResponse
{
  [JsonProperty("replyCode")] public int ReplyCode { get; set; }
  [JsonProperty("status")] public int Status { get; set; }
  [JsonProperty("requestId")] public string RequestId { get; set; } = string.Empty;
  [JsonProperty("requestTime")] public string RequestTime { get; set; } = string.Empty;
  [JsonProperty("replyMessage")] public string ReplyMessage { get; set; } = string.Empty;
  [JsonProperty("data")] public CheckData Data { get; set; } = new();
}
