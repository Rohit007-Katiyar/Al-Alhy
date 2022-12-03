using AhliFans.Core.Feature.Admin.Notification.Manual.Send.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Notification.Manual;

public class SendNotificationEndPoint : EndpointBaseAsync
  .WithRequest<SendNotificationRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public SendNotificationEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(SendNotificationRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Send Notification",
    Description = "Admin Send Notification",
    OperationId = "Admin.SendNotification",
    Tags = new[] {"Notification Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]SendNotificationRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new SendNotificationEvent(request.Header,request.Body,request.Icon,request.Link),cancellationToken);
}
