using AhliFans.Core;
using AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Goals;

public class GetGoalsByMatchIdEndpoint : EndpointBaseAsync
.WithRequest<GetGoalsByMatchIdRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public GetGoalsByMatchIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize(nameof(Roles.Admin))]
  [HttpGet(GetGoalsByMatchIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MatchGoalDto>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
  Summary = "Admin Get Match Goals",
  Description = "Admin Get Match Goals",
  OperationId = "Admin.GetMatchGoals",
  Tags = new[] { "Match Center Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] GetGoalsByMatchIdRequest request, CancellationToken cancellationToken = default)
  {
    var getGoalsEvent = new GetGoalsByMatchIdEvent(request.MatchId, request.Lang ?? Languages.Ar);
    return await _mediator.Send(getGoalsEvent, cancellationToken);
  }
}