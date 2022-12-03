using AhliFans.Core.Feature.Admin.League.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.League;

public class EditLeagueEndPoint : EndpointBaseAsync
  .WithRequest<EditLeagueRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditLeagueEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(EditLeagueRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Edit League",
    Description = "Admin Edit League",
    OperationId = "Admin.EditLeague",
    Tags = new[] {"League Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(EditLeagueRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new EditLeagueEvent(request.LeagueId, request.Name, request.NameAr, request.LeagueDateTimes),cancellationToken);
}
