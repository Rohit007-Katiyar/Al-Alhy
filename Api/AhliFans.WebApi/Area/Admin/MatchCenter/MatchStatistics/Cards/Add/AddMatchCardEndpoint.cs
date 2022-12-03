using AhliFans.Core;
using AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics;

public class AddMatchCardEndpoint : EndpointBaseAsync
.WithRequest<AddMatchCardRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public AddMatchCardEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpPost(AddMatchCardRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
    Summary = "Admin Add Match Card",
    Description = "Admin Add Match Card",
    OperationId = "Admin.AddMatchCard",
    Tags = new[] { "Match Center Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromBody] AddMatchCardRequest request, CancellationToken cancellationToken = default)
  {
    var addMatchCardEvent = new AddMatchCardEvent(request.MatchId, request.PlayerId, request.IsRed, request.IsForAhly, request.Minute);
    return await _mediator.Send(addMatchCardEvent, cancellationToken);
  }
}