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

public class GetMatchStatisticByIdEndpoint : EndpointBaseAsync
.WithRequest<GetMatchStatisticByIdRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public GetMatchStatisticByIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpGet(GetMatchStatisticByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MatchStatisticDetailsDto))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
    Summary = "Admin Get Match Statistic Details",
    Description = "Admin Get Match Statistic By Id",
    OperationId = "Admin.GetMatchStatistic",
    Tags = new[] { "Match Center Endpoints" })
    ]
  public override async Task<ActionResult> HandleAsync([FromRoute] GetMatchStatisticByIdRequest request, CancellationToken cancellationToken = default)
  {
    var getByIdEvent = new GetStatisticByIdEvent(request.Id, request.Lang ?? Languages.Ar);
    return await _mediator.Send(getByIdEvent, cancellationToken);
  }
}