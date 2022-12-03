using System.Text;
using AhliFans.Core.Feature.Fan.Notification;
using AhliFans.Core.Feature.Fan.Notification.Manual.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Notification.Manual.GetById;

public class GetNotificationByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetNotificationByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetNotificationByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetNotificationByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanNotificationDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get Notification By Id",
    Description = "Client Get Notification By Id",
    OperationId = "Client.GetNotification",
    Tags = new[] {"Notification Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetNotificationByIdRequest request,
    CancellationToken cancellationToken = default)
  {
    var imageBaseUrl = new StringBuilder(Request.Scheme).Append("://")
      .Append(Request.Host)
      .Append(Request.PathBase.ToString()).Append("/")
      .Append(GetIconRequest.Route.Replace("{NotificationId}",""))
      .ToString();

    return  await _mediator.Send(new GetNotificationByIdEvent(request.NotificationId,imageBaseUrl), cancellationToken);
  }
}
