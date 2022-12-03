using AhliFans.Core;
using AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public class GetAllStatisticGroupCoefficientEndpoint : EndpointBaseAsync
.WithRequest<GetAllStatisticGroupCoefficientRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllStatisticGroupCoefficientEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize(nameof(Roles.Admin))]
  [HttpGet(GetAllStatisticGroupCoefficientRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<StatisticGroupCoefficientDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [SwaggerOperation(
  Summary = "Admin Get All Match Statistic Group Coefficients",
  Description = "Admin Get All Match Statistic Group Coefficients By Group Id",
  OperationId = "Admin.GetAllMatchStatisticGroupCoefficients",
  Tags = new[] { "Match Center Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetAllStatisticGroupCoefficientRequest request, CancellationToken cancellationToken = default)
  {
    var getAllCoefficientsEvent = new GetAllStatisticGroupCoefficientsEvent(request.StatisticTypeId, request.PageIndex, request.PageSize, request.Name, request.Lang ?? Languages.Ar);
    return await _mediator.Send(getAllCoefficientsEvent, cancellationToken);
  }
}
