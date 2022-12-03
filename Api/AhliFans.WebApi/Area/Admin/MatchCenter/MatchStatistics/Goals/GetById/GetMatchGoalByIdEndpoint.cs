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

public class GetMatchGoalByIdEndpoint : EndpointBaseAsync
.WithRequest<GetMatchGoalByIdRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public GetMatchGoalByIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpGet(GetMatchGoalByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MatchGoalDto))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
    Summary = "Admin Get Match Goal By Id",
    Description = "Admin Get Match Goal By Id",
    OperationId = "Admin.GetMatchGoalById",
    Tags = new[] { "Match Center Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] GetMatchGoalByIdRequest request, CancellationToken cancellationToken = default)
  {
    var getByIdEvent = new GetMatchGoalByIdEvent(request.Id, request.Lang ?? Languages.Ar);
    return await _mediator.Send(getByIdEvent, cancellationToken);
  }
}