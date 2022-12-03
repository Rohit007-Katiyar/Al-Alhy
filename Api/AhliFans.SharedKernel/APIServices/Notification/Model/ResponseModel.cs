#nullable disable
using Newtonsoft.Json;

namespace AhliFans.SharedKernel.APIServices.Notification.Model;

public class ResponseModel
{
    [JsonProperty("isSuccess")]
    public bool IsSuccess { get; set; }
    [JsonProperty("message")]
    public string Message { get; set; }
}
