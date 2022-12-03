using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Notification;

public class GetNotificationEventHandler : IRequestHandler<GetManualNotificationEvent,ActionResult>
{
  private readonly IRepository<Entities.FanNotification> _notificationRepository;
  private readonly string _userId;

  public GetNotificationEventHandler(IHttpContextAccessor context,IRepository<Entities.FanNotification> notificationRepository)
  {
    _notificationRepository = notificationRepository;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
  }
  public async Task<ActionResult> Handle(GetManualNotificationEvent request, CancellationToken cancellationToken)
  {
    var notification = await _notificationRepository.ListAsync(new GetAllNotification(request.PageIndex,request.PageSize,Guid.Parse(_userId)), cancellationToken);
    if (notification.Count == 0) return new OkObjectResult(Enumerable.Empty<FanNotificationDto>());
    return new OkObjectResult(notification.Select(n => new FanNotificationDto(n.NotificationId,n.Notification.Header, n.Notification.Body, n.Notification.Link, n.Notification.SendTime,n.Read,request.ImageUrl+n.NotificationId)));
  }
}
