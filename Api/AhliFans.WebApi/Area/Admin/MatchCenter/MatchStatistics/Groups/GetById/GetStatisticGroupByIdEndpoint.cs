using AhliFans.Core;
using AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Groups;

public class GetStatisticGroupByIdEndpoint : EndpointBaseAsync
.WithRequest<GetStatisticGroupByIdRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public GetStatisticGroupByIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  
  [Authorize(nameof(Roles.Admin))]
  [HttpGet(GetStatisticGroupByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StatisticGroupDetailsDto))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
  Summary = "Admin Get Match Statistic Group By Id",
  Description = "Admin Get Match Statistic Group By Id",
  OperationId = "Admin.GetMatchStatisticGroupById",
  Tags = new[] { "Match Center Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] GetStatisticGroupByIdRequest request, CancellationToken cancellationToken = default)
  {
    var getById = new GetStatisticGroupByIdEvent(request.StatisticGroupId);
    return await _mediator.Send(getById, cancellationToken);
  }
}
