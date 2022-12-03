using AhliFans.Core.Feature.Admin.Notification.Manual.Get.DTO;
using AhliFans.Core.Feature.Admin.Notification.Manual.Get.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Notification.Manual;

public class GetManualNotificationEndPoint : EndpointBaseAsync
  .WithRequest<GetManualNotificationRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetManualNotificationEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpGet(GetManualNotificationRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NotificationDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Notification",
    Description = "Admin Get Notification",
    OperationId = "Admin.GetNotification",
    Tags = new[] { "Notification Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetManualNotificationRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetManualNotificationEvent(request.PageSize,request.PageIndex), cancellationToken);
}
