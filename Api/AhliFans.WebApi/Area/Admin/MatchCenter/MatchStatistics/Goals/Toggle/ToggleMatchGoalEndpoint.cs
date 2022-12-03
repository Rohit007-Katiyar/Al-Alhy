using AhliFans.Core;
using AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Goals;

public class ToggleMatchGoalEndpoint : EndpointBaseAsync
.WithRequest<ToggleMatchGoalRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public ToggleMatchGoalEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize(nameof(Roles.Admin))]
  [HttpPatch(ToggleMatchGoalRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
  Summary = "Admin Disable/Enable Match Goal",
  Description = "Admin Disable/Enable Match Goal",
  OperationId = "Admin.ToggleMatchGoals",
  Tags = new[] { "Match Center Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] ToggleMatchGoalRequest request, CancellationToken cancellationToken = default)
  {
    var ev = new ToggleMatchGoalEvent(request.GoalId);
    return await _mediator.Send(ev, cancellationToken);
  }
}