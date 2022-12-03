using AhliFans.Core.Feature.Admin.MatchCenter.Substitution.Create;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.LineUp;

public class CreateSubstitutionEndPoint : EndpointBaseAsync
  .WithRequest<CreateSubstitutionRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public CreateSubstitutionEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(CreateSubstitutionRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Create Substitution",
    Description = "Admin Create Substitution",
    OperationId = "Admin.AddSubstitution",
    Tags = new[] { "Substitution Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(CreateSubstitutionRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new CreateSubstitutionEvent(request.PlayerId, request.SubstitutionPlayer,request.MatchId), cancellationToken);
}
