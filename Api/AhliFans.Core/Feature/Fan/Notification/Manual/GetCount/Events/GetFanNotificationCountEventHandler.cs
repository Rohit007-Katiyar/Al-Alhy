using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.Notification.Manual.GetCount.Specification;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Notification.Manual.GetCount.Events;

public class GetFanNotificationCountEventHandler : IRequestHandler<GetFanNotificationCountEvent,ActionResult>
{
  private readonly IRepository<FanNotification> _notificationRepository;
  private readonly string _userId;

  public GetFanNotificationCountEventHandler(IHttpContextAccessor context,IRepository<FanNotification> notificationRepository)
  {
    _notificationRepository = notificationRepository;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
  }
  public async Task<ActionResult> Handle(GetFanNotificationCountEvent request, CancellationToken cancellationToken)
  {
    var count = await _notificationRepository.CountAsync(new GetFanNotificationCount(Guid.Parse(_userId)),cancellationToken);
    return new OkObjectResult(count);
  }
}
