using AhliFans.Core;
using AhliFans.Core.Feature.Fan.MatchCenter.Vote;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.MatchCenter.Vote;

public class GetTopByMatchIdEndpoint : EndpointBaseAsync
.WithRequest<GetTopByMatchIdRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public GetTopByMatchIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Fan))]
  [HttpGet(GetTopByMatchIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<TopVoteDto>))]
  [SwaggerOperation(
      Summary = "Fan get match top votes",
      Description = "Fan get match top votes by match id",
      OperationId = "Client.GetTopVotes",
      Tags = new[] { "Match Center Endpoints" })
    ]
  public override async Task<ActionResult> HandleAsync([FromRoute] GetTopByMatchIdRequest request, CancellationToken cancellationToken = default)
  {
    var ev = new GetTopByMatchIdEvent(request.MatchId, request.Top == default ? 3 : request.Top, request.Lang ?? Languages.Ar);
    return await _mediator.Send(ev, cancellationToken);
  }
}