using AhliFans.Core.Feature.Fan.Notification;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Notification;

public class GetIconEndPoint : EndpointBaseAsync
  .WithRequest<GetIconRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetIconEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetIconRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IFormFile))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get Notification Icon By Id",
    Description = "Client Get Notification Icon By Id",
    OperationId = "Client.GetNotificationIcon",
    Tags = new[] { "Notification Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute]GetIconRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetNotificationIconEvent(request.NotificationId), cancellationToken);
}
