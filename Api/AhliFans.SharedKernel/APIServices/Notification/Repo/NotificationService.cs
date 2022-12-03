using AhliFans.SharedKernel.APIServices.Notification.Model;
using FirebaseAdmin.Messaging;

namespace AhliFans.SharedKernel.APIServices.Notification.Repo;

public class NotificationService : INotificationService
{
  public async Task<ResponseModel> SendNotification(NotificationModel notificationModel)
    {
        var message = new MulticastMessage()
          {
            Data = new Dictionary<string, string>()
            {
               { "notificationId", notificationModel.NotificationId.ToString()},
            },
            Tokens = notificationModel.Tokens,
            Notification = new FirebaseAdmin.Messaging.Notification()
            {
              Title = notificationModel.Title,
              Body = notificationModel.Body,
            },
            Android = new AndroidConfig()
            {
              Notification = new AndroidNotification()
              {
                ChannelId = "push"
              }
            }

          };
        var response = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(message);
        return new ResponseModel()
        {
          IsSuccess = true,Message = response.Responses.ToString()
        };
    }
}
