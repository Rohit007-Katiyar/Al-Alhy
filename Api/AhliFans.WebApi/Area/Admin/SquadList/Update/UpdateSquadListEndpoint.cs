using AhliFans.Core;
using AhliFans.Core.Feature.Admin.SquadList.Update.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.SquadList;

public class UpdateSquadListEndpoint : EndpointBaseAsync
.WithRequest<UpdateSquadListRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public UpdateSquadListEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpPut(UpdateSquadListRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [SwaggerOperation(
  Summary = "Admin update match squad list",
  Description = "Admin update match squad list by match id",
  OperationId = "Admin.UpdateSquadListMember",
  Tags = new[] { "Squad List Endpoints" })
]
  public override async Task<ActionResult> HandleAsync(UpdateSquadListRequest request, CancellationToken cancellationToken = default)
  {
    return await _mediator.Send(new UpdateSquadListEvent(request.PlayersIds, request.MatchId), cancellationToken);
  }
}
