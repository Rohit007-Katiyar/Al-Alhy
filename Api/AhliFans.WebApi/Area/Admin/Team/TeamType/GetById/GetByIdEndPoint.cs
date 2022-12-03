using AhliFans.Core.Feature.Admin.Team.TeamType.GetById.DTO;
using AhliFans.Core.Feature.Admin.Team.TeamType.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Team.TeamType;

public class GetByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeamTypeDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Team Type",
    Description = "Admin Get Team Type",
    OperationId = "Admin.GetTeamType",
    Tags = new[] {"Team Type Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetTeamTypeByIdEvent(request.TeamTypeId), cancellationToken);
}
