using AhliFans.Core.Feature.Fan.Notification.Setting.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Notification.Setting.Add;

public class AddSettingEndPoint : EndpointBaseAsync
  .WithRequest<AddSettingRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddSettingEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpPost(AddSettingRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Add Notification Setting",
    Description = "Client Add Notification Setting",
    OperationId = "Client.AddNotificationsSetting",
    Tags = new[] { "Notification Setting Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(AddSettingRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddSettingEvent(request.FanId,request.EnableAll, request.PlaySounds, request.News, request.MatchStatus,
      request.NightMode, request.From, request.To),cancellationToken);
}
