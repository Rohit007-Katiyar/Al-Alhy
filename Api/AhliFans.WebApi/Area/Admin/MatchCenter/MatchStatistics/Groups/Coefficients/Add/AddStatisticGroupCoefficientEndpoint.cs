using AhliFans.Core;
using AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public class AddStatisticGroupCoefficientEndpoint : EndpointBaseAsync
.WithRequest<AddStatisticGroupCoefficientRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public AddStatisticGroupCoefficientEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpPost(AddStatisticGroupCoefficientRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
  Summary = "Admin Add Match Statistic Group Coefficient",
  Description = "Admin Add Match Statistic Group Coefficient",
  OperationId = "Admin.AddMatchStatisticGroupCoefficient",
  Tags = new[] { "Match Center Endpoints" })
]
  public override async Task<ActionResult> HandleAsync(AddStatisticGroupCoefficientRequest request, CancellationToken cancellationToken = default)
  {
    var addEvent = new AddStatisticGroupCoefficientEvent(request.StatisticTypeId, request.Name, request.NameAr, request.IsPercentage);
    return await _mediator.Send(addEvent, cancellationToken);
  }
}
