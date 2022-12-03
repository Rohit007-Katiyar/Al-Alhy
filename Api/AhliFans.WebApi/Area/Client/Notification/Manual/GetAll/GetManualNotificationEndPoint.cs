using System.Text;
using AhliFans.Core.Feature.Fan.Notification;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Notification;

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
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<FanNotificationDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get Notification",
    Description = "Client Get Notification",
    OperationId = "Client.GetNotifications",
    Tags = new[] {"Notification Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetManualNotificationRequest request,
    CancellationToken cancellationToken = default)
  {
    var imageBaseUrl = new StringBuilder(Request.Scheme).Append("://")
      .Append(Request.Host)
      .Append(Request.PathBase.ToString()).Append("/")
      .Append(GetIconRequest.Route.Replace("{NotificationId}", ""))
      .ToString();

    return await _mediator.Send(new GetManualNotificationEvent(request.PageSize, request.PageIndex, imageBaseUrl), cancellationToken);
  }
}
