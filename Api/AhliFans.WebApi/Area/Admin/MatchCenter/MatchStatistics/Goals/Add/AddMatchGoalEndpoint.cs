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

public class AddMatchGoalEndpoint : EndpointBaseAsync
.WithRequest<AddMatchGoalRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public AddMatchGoalEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpPost(AddMatchGoalRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
  Summary = "Admin Add Match Goal",
  Description = "Admin Add Match Goal",
  OperationId = "Admin.AddMatchGoal",
  Tags = new[] { "Match Center Endpoints" })
  ]

  public override async Task<ActionResult> HandleAsync([FromBody] AddMatchGoalRequest request, CancellationToken cancellationToken = default)
  {
    var addEvent = new AddMatchGoalEvent(request.MatchId, request.PlayerId, request.Minute, request.IsForAhly);
    return await _mediator.Send(addEvent, cancellationToken);
  }
}