#nullable disable
using Newtonsoft.Json;
namespace AhliFans.SharedKernel.APIServices.Notification.Model;

public class NotificationModel
{
    [JsonProperty("tokens")]
    public List<string> Tokens { get; set; }

    [JsonProperty("notificationId")]
    public int NotificationId { get; set; } 

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("body")]
    public string Body { get; set; }

}
