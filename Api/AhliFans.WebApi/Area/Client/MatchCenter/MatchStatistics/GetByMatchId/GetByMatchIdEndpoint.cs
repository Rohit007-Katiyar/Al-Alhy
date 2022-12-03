using AhliFans.Core.Feature.Fan.MatchCenter.MatchStatistics;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.MatchCenter.MatchStatistics;

public class GetByMatchIdEndpoint : EndpointBaseAsync
.WithRequest<GetByMatchIdRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public GetByMatchIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetByMatchIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MatchStatisticsDto))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Fan get match statistics by match id",
    Description = "Fan get match statistics by match id",
    OperationId = "Client.GetMatchStatistics",
    Tags = new[] { "Match Center Endpoints" })
    ]
  public override async Task<ActionResult> HandleAsync([FromRoute] GetByMatchIdRequest request, CancellationToken cancellationToken = default)
  {
    var ev = new GetByMatchIdEvent(request.MatchId, request.Lang ?? Languages.Ar);
    return await _mediator.Send(ev, cancellationToken);
  }
}