using AhliFans.Core;
using AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Cards;

public class ToggleMatchCardEndpoint : EndpointBaseAsync
.WithRequest<ToggleMatchCardRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public ToggleMatchCardEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize(nameof(Roles.Admin))]
  [HttpPatch(ToggleMatchCardRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
        Summary = "Admin Disable/Enable Match Cards By Card Id",
        Description = "Admin Disable/Enable Match Cards By Card Id",
        OperationId = "Admin.ToggleMatchCards",
        Tags = new[] { "Match Center Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] ToggleMatchCardRequest request, CancellationToken cancellationToken = default)
  {
    var ev = new ToggleMatchCardEvent(request.CardId);
    return await _mediator.Send(ev, cancellationToken);
  }
}
