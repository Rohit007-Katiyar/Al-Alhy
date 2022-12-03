using AhliFans.Core.Feature.Fan.Referee.GetByMatch.DTO;
using AhliFans.Core.Feature.Fan.Referee.GetByMatch.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Referee;

public class GetRefereeByMatchIdEndPoint : EndpointBaseAsync
  .WithRequest<GetRefereeByMatchRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetRefereeByMatchIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetRefereeByMatchRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RefereeByMatchDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client get referee by match id",
    Description = "Client get referee by match id",
    OperationId = "Client.RefereeByMatch",
    Tags = new[] { "Referee Endpoints" })]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetRefereeByMatchRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetRefereeByMatchEvent(request.MatchId, request.Lang),cancellationToken);
}
