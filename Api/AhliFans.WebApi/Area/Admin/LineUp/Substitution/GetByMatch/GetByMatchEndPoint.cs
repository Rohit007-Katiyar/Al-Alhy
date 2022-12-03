using AhliFans.Core.Feature.Admin.MatchCenter.Substitution.GetByMatchId.DTO;
using AhliFans.Core.Feature.Admin.MatchCenter.Substitution.GetByMatchId.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.LineUp.Substitution.GetByMatch;

public class GetByMatchEndPoint : EndpointBaseAsync
  .WithRequest<GetByMatchRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetByMatchEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpGet(GetByMatchRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<SubstitutionDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Substitution",
    Description = "Admin Get Substitution",
    OperationId = "Admin.GetSubstitution",
    Tags = new[] { "Substitution Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetByMatchRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetSubstitutionByMatchEvent(request.MatchId, request.Lang),cancellationToken);
}
