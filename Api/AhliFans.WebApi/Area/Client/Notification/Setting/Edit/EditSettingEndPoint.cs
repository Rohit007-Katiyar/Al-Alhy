using AhliFans.Core.Feature.Fan.Notification.Setting.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Notification.Setting.Edit;

public class EditSettingEndPoint : EndpointBaseAsync
  .WithRequest<EditSettingRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditSettingEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(EditSettingRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Edit Notification Setting",
    Description = "Client Edit Notification Setting",
    OperationId = "Client.EditNotificationsSetting",
    Tags = new[] { "Notification Setting Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(EditSettingRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new EditNotificationSettingsEvent(request.EnableAll, request.PlaySounds, request.News,
      request.MatchStatus, request.NightMode, request.From, request.To),cancellationToken);
}
