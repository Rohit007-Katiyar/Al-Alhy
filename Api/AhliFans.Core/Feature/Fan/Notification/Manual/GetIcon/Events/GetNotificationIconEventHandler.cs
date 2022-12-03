using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Notification;
public class GetTrophyImageEventHandler : IRequestHandler<GetNotificationIconEvent,ActionResult>
{
  private readonly IRepository<Entities.Notification> _notificationRepository;
  private readonly IFileManager _fileManager;
  public GetTrophyImageEventHandler(IRepository<Entities.Notification> notificationRepository, IFileManager fileManager)
  {
    _notificationRepository = notificationRepository;
    _fileManager = fileManager;
  }
  public async Task<ActionResult> Handle(GetNotificationIconEvent request, CancellationToken cancellationToken)
  {
    var notification = await _notificationRepository.GetByIdAsync(request.NotificationId,cancellationToken);
    if (notification is null) return new NotFoundObjectResult(new FanResponse("Not found", ResponseStatus.Error));

    var notificationIcon = string.IsNullOrEmpty(notification.Icon) ?
      await _fileManager.FileProxy<Entities.Notification>("defaultNotification.png", "") :
      await _fileManager.FileProxy<Entities.Notification>(notification.Icon, notification.Id.ToString());

    try
    {
      var streamReader = await notificationIcon.ReadStreamAsync();
      return new FileStreamResult(streamReader, _fileManager.GetContentType(string.IsNullOrEmpty(notification.Icon) ? "defaultNotification.png" : notification.Icon));
    }
    catch
    {
      return new BadRequestObjectResult(new FanResponse("Can't get the image", ResponseStatus.Error));
    }
  }
}
