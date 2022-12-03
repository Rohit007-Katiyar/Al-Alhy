using AhliFans.Core;
using AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Cards;

public class GetCardsByMatchIdEndpoint : EndpointBaseAsync
.WithRequest<GetCardsByMatchIdRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public GetCardsByMatchIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpGet(GetCardsByMatchIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MatchCardDto>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
        Summary = "Admin Get Match Cards By Match Id",
        Description = "Admin Get Match Cards By Match Id",
        OperationId = "Admin.GetMatchCards",
        Tags = new[] { "Match Center Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] GetCardsByMatchIdRequest request, CancellationToken cancellationToken = default)
  {
    var ev = new GetCardsByMatchIdEvent(request.MatchId, request.Lang ?? Languages.Ar);
    return await _mediator.Send(ev, cancellationToken);
  }
}