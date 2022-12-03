using AhliFans.Core;
using AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics;

public class GetAllMatchStatisticsEndpoint : EndpointBaseAsync
.WithRequest<GetAllMatchStatisticsRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllMatchStatisticsEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize(nameof(Roles.Admin))]
  [HttpGet(GetAllMatchStatisticsRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MatchStatisticDto>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
  Summary = "Admin Get All Match Statistics",
  Description = "Admin Get All Match Statistics",
  OperationId = "Admin.GetAllMatchStatistics",
  Tags = new[] { "Match Center Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetAllMatchStatisticsRequest request, CancellationToken cancellationToken = default)
  {
    var getEvent = new GetAllMatchStatisticsEvent(request.MatchId, request.PageIndex, request.PageSize, request.Lang ?? Languages.Ar);
    return await _mediator.Send(getEvent, cancellationToken);
  }
}