using AhliFans.Core.Feature.Admin.Team.Add.Edit.Event;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Team;

public class EditTeamEndPoint : EndpointBaseAsync
  .WithRequest<EditTeamRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditTeamEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(EditTeamRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Edit Team",
    Description = "Admin Edit Team",
    OperationId = "Admin.EditTeam",
    Tags = new[] {"Team Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]EditTeamRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new EditTeamEvent(request.TeamId,request.TypeId,request.RegionId,request.Name,request.NameAr), cancellationToken);
}
