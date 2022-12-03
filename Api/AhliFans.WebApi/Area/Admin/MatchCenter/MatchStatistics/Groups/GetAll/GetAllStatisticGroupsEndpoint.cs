using AhliFans.Core;
using AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Groups;

public class GetAllStatisticGroupsEndpoint : EndpointBaseAsync
.WithRequest<GetAllStatisticGroupsRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllStatisticGroupsEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpGet(GetAllStatisticGroupsRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<StatisticGroupDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
  Summary = "Admin Get All Match Statistic Groups",
  Description = "Admin Get All Match Statistic Groups",
  OperationId = "Admin.GetAllMatchStatisticGroups",
  Tags = new[] { "Match Center Endpoints" })
  ]

  public override async Task<ActionResult> HandleAsync([FromQuery] GetAllStatisticGroupsRequest request, CancellationToken cancellationToken = default)
  {
    var getAllEvent = new GetAllStatisticGroupsEvent(request.PageIndex, request.PageSize, request.Name, request.Lang ?? Languages.Ar);
    return await _mediator.Send(getAllEvent, cancellationToken);
  }
}
