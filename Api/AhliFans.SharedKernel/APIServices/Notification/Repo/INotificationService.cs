
using AhliFans.SharedKernel.APIServices.Notification.Model;

namespace AhliFans.SharedKernel.APIServices.Notification.Repo;

public interface INotificationService
{
    Task<ResponseModel> SendNotification(NotificationModel notificationModel);
}
