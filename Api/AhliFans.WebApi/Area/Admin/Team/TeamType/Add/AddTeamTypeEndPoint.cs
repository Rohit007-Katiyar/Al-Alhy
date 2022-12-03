using AhliFans.Core.Feature.Admin.Team.TeamType.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Team.TeamType;

public class AddTeamTypeEndPoint : EndpointBaseAsync
  .WithRequest<AddTeamTypeRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddTeamTypeEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPost(AddTeamTypeRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add New Team Type",
    Description = "Admin Add New Team Type",
    OperationId = "Admin.AddTeamType",
    Tags = new[] { "Team Type Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(AddTeamTypeRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddTeamTypeEvent(request.Name,request.NameAr),cancellationToken);
}
