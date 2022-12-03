using AhliFans.Core.Feature.Admin.Team.Logo.Get.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Team.Logo;

public class GetLogoEndPoint : EndpointBaseAsync
  .WithRequest<GetLogoRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetLogoEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetLogoRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IFormFile))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Team Logo By Id",
    Description = "Admin Get Team Logo By Id",
    OperationId = "Admin.GetTeamLogo",
    Tags = new[] { "Team Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute]GetLogoRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetTeamLogoEvent(request.TeamId), cancellationToken);
}
