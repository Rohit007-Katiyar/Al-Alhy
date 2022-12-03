using AhliFans.Core;
using AhliFans.Core.Feature.Admin.SquadList.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.SquadList;

public class AddSquadEndPoint : EndpointBaseAsync
  .WithRequest<AddSquadListRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddSquadEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Admin))]
  [HttpPost(AddSquadListRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin add squad list member",
    Description = "Admin add squad list member",
    OperationId = "Admin.AddSquadListMember",
    Tags = new[] { "Squad List Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(AddSquadListRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddSquadListEvent(request.PlayersIds, request.MatchId), cancellationToken);
}
