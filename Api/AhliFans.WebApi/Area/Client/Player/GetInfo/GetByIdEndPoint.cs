using AhliFans.Core.Feature.Fan.Player.GetInfo.DTO;
using AhliFans.Core.Feature.Fan.Player.GetInfo.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Player;

public class GetByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [AllowAnonymous]
  [HttpGet(GetByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlayerInfoDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get Player By His Id",
    Description = "Client Get Player By His Id",
    OperationId = "Client.GetPlayer",
    Tags = new[] { "Player Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetPlayerByIdEvent(request.PlayerId,request.Lang), cancellationToken);
}
