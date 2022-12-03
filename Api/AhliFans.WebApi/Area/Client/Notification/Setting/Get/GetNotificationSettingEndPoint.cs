using AhliFans.Core.Feature.Fan.Notification.Setting.Get.DTO;
using AhliFans.Core.Feature.Fan.Notification.Setting.Get.Event;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Notification.Setting.Get;

public class GetNotificationSettingEndPoint : EndpointBaseAsync
  .WithoutRequest
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetNotificationSettingEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetNotificationSettingRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserNotificationSettingDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get Notification Setting",
    Description = "Client Get Notification Setting",
    OperationId = "Client.GetNotificationsSetting",
    Tags = new[] {"Notification Setting Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetNotificationSettingEvent(), cancellationToken);
}
