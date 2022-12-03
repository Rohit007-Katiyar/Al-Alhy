using AhliFans.Core.Feature.Fan.Notification.Manual.GetCount.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Notification.Manual.GetCount;

public class GetNotificationCountEndPoint : EndpointBaseAsync
  .WithoutRequest
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetNotificationCountEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetNotificationCountRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get Notification Count",
    Description = "Client Get Notification Count",
    OperationId = "Client.GetNotificationCount",
    Tags = new[] {"Notification Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetFanNotificationCountEvent(), cancellationToken);
}
