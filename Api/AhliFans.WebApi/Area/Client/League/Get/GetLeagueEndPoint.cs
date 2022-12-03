using AhliFans.Core.Feature.Fan.League.Get.DTO;
using AhliFans.Core.Feature.Fan.League.Get.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.League;

public class GetLeagueEndPoint : EndpointBaseAsync
  .WithRequest<GetLeagueRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetLeagueEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetLeagueRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<LeaguesDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get All Leagues",
    Description = "Client Get All Leagues",
    OperationId = "Client.AllLeague",
    Tags = new[] {"League Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetLeagueRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetLeagueEvent(request.LeagueId, request.LeagueName,request.Lang), cancellationToken);
}
