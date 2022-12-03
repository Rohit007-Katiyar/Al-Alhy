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

public class EditStatisticEndpoint : EndpointBaseAsync
.WithRequest<EditStatisticRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public EditStatisticEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpPut(AddStatisticRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
  Summary = "Admin Edit Match Statistic",
  Description = "Admin Edit Match Statistic",
  OperationId = "Admin.EditMatchStatistic",
  Tags = new[] { "Match Center Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(EditStatisticRequest request, CancellationToken cancellationToken = default)
  {
    var editEvent = new EditStatisticEvent(request.Id, request.Value, request.MatchId, request.StatisticsTypeId, request.StatisticsCoefficientId);
    return await _mediator.Send(editEvent, cancellationToken);
  }
}
