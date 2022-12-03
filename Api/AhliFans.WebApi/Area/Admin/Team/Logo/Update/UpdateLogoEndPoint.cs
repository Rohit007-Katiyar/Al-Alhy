using AhliFans.Core.Feature.Admin.Team.Logo.Update.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Team.Logo;

public class UpdateLogoEndPoint : EndpointBaseAsync
  .WithRequest<UpdateLogoRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public UpdateLogoEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPut(UpdateLogoRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Update Team Logo By Id",
    Description = "Admin Update Team Logo By Id",
    OperationId = "Admin.UpdateTeamLogo",
    Tags = new[] { "Team Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]UpdateLogoRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new UpdateTeamLogoEvent(request.TeamId, request.TeamLogo), cancellationToken);
}
