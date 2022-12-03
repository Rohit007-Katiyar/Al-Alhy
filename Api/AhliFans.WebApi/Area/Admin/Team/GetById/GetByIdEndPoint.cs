using AhliFans.Core.Feature.Admin.Team.GetById.DTO;
using AhliFans.Core.Feature.Admin.Team.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Team;

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
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeamDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Team",
    Description = "Admin Get Team",
    OperationId = "Admin.GetTeam",
    Tags = new[] {"Team Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetTeamByIdEvent(request.TeamId,request.Lang), cancellationToken);
}
