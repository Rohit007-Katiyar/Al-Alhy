using AhliFans.Core.Feature.Fan.MatchCenter.MatchStatistics;
using AhliFans.Core.Feature.Fan.MatchCenter.MatchStatistics.Goals;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.MatchCenter.MatchStatistics.Goals;

public class GetGoalsByMatchIdEndpoint : EndpointBaseAsync
.WithRequest<GetGoalsByMatchIdRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public GetGoalsByMatchIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetGoalsByMatchIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MatchGoalDto>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(FanResponse))]
  [SwaggerOperation(
  Summary = "Fan get match goals by match id",
  Description = "Fan get match goals by match id",
  OperationId = "Client.GetMatchGoals",
  Tags = new[] { "Match Center Endpoints" })
  ]

  public override async Task<ActionResult> HandleAsync([FromRoute] GetGoalsByMatchIdRequest request, CancellationToken cancellationToken = default)
  {
    var getGoalsEvent = new GetGoalsByMatchIdEvent(request.MatchId, request.Lang ?? Languages.Ar);
    return await _mediator.Send(getGoalsEvent, cancellationToken);
  }
}