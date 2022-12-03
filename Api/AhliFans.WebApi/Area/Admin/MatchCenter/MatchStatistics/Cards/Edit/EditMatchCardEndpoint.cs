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

public class EditMatchCardEndpoint : EndpointBaseAsync
.WithRequest<EditMatchCardRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public EditMatchCardEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpPut(EditMatchCardRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
      Summary = "Admin Edit Match Card",
      Description = "Admin Edit Match Card",
      OperationId = "Admin.EditMatchCard",
      Tags = new[] { "Match Center Endpoints" })
    ]
  public override async Task<ActionResult> HandleAsync([FromBody] EditMatchCardRequest request, CancellationToken cancellationToken = default)
  {
    var ev = new EditMatchCardEvent(request.Id, request.PlayerId, request.IsForAhly, request.IsRed, request.Minute);
    return await _mediator.Send(ev, cancellationToken);
  }
}