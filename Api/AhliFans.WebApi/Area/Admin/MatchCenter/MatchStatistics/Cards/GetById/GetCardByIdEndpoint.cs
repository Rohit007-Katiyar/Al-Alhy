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

public class GetCardByIdEndpoint : EndpointBaseAsync
.WithRequest<GetCardByIdRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public GetCardByIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpGet(GetCardByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MatchCardDto))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
    Summary = "Admin Get Match Card By Id",
    Description = "Admin Get Match Card By Id",
    OperationId = "Admin.GetMatchCard",
    Tags = new[] { "Match Center Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] GetCardByIdRequest request, CancellationToken cancellationToken = default)
  {
    var ev = new GetMatchCardByIdEvent(request.CardId, request.Lang ?? Languages.Ar);
    return await _mediator.Send(ev, cancellationToken);
  }
}