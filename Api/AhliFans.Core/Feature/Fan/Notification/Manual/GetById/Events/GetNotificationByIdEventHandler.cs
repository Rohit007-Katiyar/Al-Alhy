using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.Notification.Manual.GetById.Specifications;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Notification.Manual.GetById.Events;

public class GetNotificationByIdEventHandler : IRequestHandler<GetNotificationByIdEvent,ActionResult>
{
  private readonly IRepository<FanNotification> _fanNotification;

  public GetNotificationByIdEventHandler(IRepository<FanNotification> fanNotification)
  {
    _fanNotification = fanNotification;
  }
  public async Task<ActionResult> Handle(GetNotificationByIdEvent request, CancellationToken cancellationToken)
  {
    var fanNotification = await _fanNotification.GetBySpecAsync(new GetNotificationById(request.NotificationId), cancellationToken);
    if (fanNotification == null) return new NotFoundObjectResult(new FanResponse("Not found",ResponseStatus.Error));
    fanNotification.Read = true;
    await _fanNotification.UpdateAsync(fanNotification,cancellationToken);
    await _fanNotification.SaveChangesAsync(cancellationToken);
    return new OkObjectResult(new FanNotificationDto(fanNotification.Notification.Id, fanNotification.Notification.Header, fanNotification.Notification.Body,fanNotification.Notification.Link,
      fanNotification.Notification.SendTime, fanNotification.Read, request.ImageUrl+fanNotification.NotificationId));
  }
}
