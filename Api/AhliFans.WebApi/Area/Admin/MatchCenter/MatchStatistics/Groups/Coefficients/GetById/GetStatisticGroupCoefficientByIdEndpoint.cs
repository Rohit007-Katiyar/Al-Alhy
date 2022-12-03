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

public class GetStatisticGroupCoefficientByIdEndpoint : EndpointBaseAsync
.WithRequest<GetStatisticGroupCoefficientByIdRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public GetStatisticGroupCoefficientByIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize(nameof(Roles.Admin))]
  [HttpGet(GetStatisticGroupCoefficientByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StatisticGroupCoefficientDetailsDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [SwaggerOperation(
  Summary = "Admin Get Match Statistic Group Coefficient By Id",
  Description = "Admin Get Match Statistic Group Coefficient By Id",
  OperationId = "Admin.AdminGetMatchStatisticGroupCoefficientById",
  Tags = new[] { "Match Center Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] GetStatisticGroupCoefficientByIdRequest request, CancellationToken cancellationToken = default)
  {
    var getById = new GetStatisticGroupCoefficientByIdEvent(request.StatisticGroupCoefficientId);
    return await _mediator.Send(getById, cancellationToken);
  }
}
