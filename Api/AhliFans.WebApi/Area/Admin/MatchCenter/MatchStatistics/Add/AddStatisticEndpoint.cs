using AhliFans.Core;
using AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics;

public class AddStatisticEndpoint : EndpointBaseAsync
.WithRequest<AddStatisticRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public AddStatisticEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  
  [Authorize(nameof(Roles.Admin))]
  [HttpPost(AddStatisticRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
  Summary = "Admin Add Match Statistic",
  Description = "Admin Add Match Statistic",
  OperationId = "Admin.AddMatchStatistic",
  Tags = new[] { "Match Center Endpoints" })
]
  public override async Task<ActionResult> HandleAsync([FromBody] AddStatisticRequest request, CancellationToken cancellationToken = default)
  {
    var addEvent = new AddStatisticEvent(request.Value, request.MatchId, request.StatisticsTypeId, request.StatisticsCoefficientId);
    return await _mediator.Send(addEvent, cancellationToken);
  }
}
