using AhliFans.Core.Feature.Admin.Notification.Manual.Get.DTO;
using AhliFans.Core.Feature.Admin.Notification.Manual.Get.Specifications;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Notification.Manual.Get.Events;

public class GetNotificationEventHandler : IRequestHandler<GetManualNotificationEvent,ActionResult>
{
  private readonly IRepository<Entities.Notification> _notificationRepository;

  public GetNotificationEventHandler(IRepository<Entities.Notification> notificationRepository)
  {
    _notificationRepository = notificationRepository;
  }
  public async Task<ActionResult> Handle(GetManualNotificationEvent request, CancellationToken cancellationToken)
  {
    var notification = await _notificationRepository.ListAsync(new GetAllNotification(request.PageIndex,request.PageSize), cancellationToken);
    if (notification.Count == 0)
      return new BadRequestObjectResult(new AdminResponse("No data yet", ResponseStatus.Error));
    return new OkObjectResult(notification.Select(n => new NotificationDto(n.Header, n.Body, n.Link, n.SendTime)));
  }
}
