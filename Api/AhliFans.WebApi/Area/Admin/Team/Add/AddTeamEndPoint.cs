using AhliFans.Core.Feature.Admin.Team.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Team;

public class AddTeamEndPoint : EndpointBaseAsync
  .WithRequest<AddTeamRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddTeamEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(AddTeamRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add New Team",
    Description = "Admin Add New Team",
    OperationId = "Admin.AddTeam",
    Tags = new[] {"Team Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromForm] AddTeamRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddTeamEvent(request.TypeId, request.RegionId, request.Name, request.NameAr, request.Logo),
      cancellationToken);
}
