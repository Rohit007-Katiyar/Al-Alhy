using AhliFans.Core.Feature.Admin.Team.TeamType.Edit.Event;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Team.TeamType;

public class EditTeamTypeEndPoint : EndpointBaseAsync
  .WithRequest<EditTeamTypeRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditTeamTypeEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(EditTeamTypeRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Edit Team Type",
    Description = "Admin Edit Team Type",
    OperationId = "Admin.EditTeamType",
    Tags = new[] {"Team Type Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromForm] EditTeamTypeRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new EditTeamTypeEvent(request.TeamTypeId, request.Name, request.NameAr), cancellationToken);
}
