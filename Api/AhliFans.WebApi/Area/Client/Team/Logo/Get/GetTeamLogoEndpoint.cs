using AhliFans.Core.Feature.Fan.Team.GetImage.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Team;


public class GetTeamLogoEndpoint : EndpointBaseAsync
.WithRequest<GetTeamLogoRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public GetTeamLogoEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetTeamLogoRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IFormFile))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Fan get team logo",
    Description = "Fan get team logo by team id",
    OperationId = "Client.GetTeamLogo",
    Tags = new[] { "Team Endpoints" })
  ]

  public override async Task<ActionResult> HandleAsync([FromRoute] GetTeamLogoRequest request, CancellationToken cancellationToken = default)
  {
    return await _mediator.Send(new GetTeamLogoEvent(request.TeamId), cancellationToken);
  }
}
