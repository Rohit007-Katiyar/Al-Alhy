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

public class EditMatchGoalEndpoint : EndpointBaseAsync
.WithRequest<EditMatchGoalRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public EditMatchGoalEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize(nameof(Roles.Admin))]
  [HttpPut(EditMatchGoalRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
  Summary = "Admin Edit Match Goal",
  Description = "Admin Edit Match Goal",
  OperationId = "Admin.EditMatchGoal",
  Tags = new[] { "Match Center Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromBody] EditMatchGoalRequest request, CancellationToken cancellationToken = default)
  {
    var editEvent = new EditMatchGoalEvent(request.Id, request.PlayerId, request.Minute, request.IsForAhly);
    return await _mediator.Send(editEvent, cancellationToken);
  }
}