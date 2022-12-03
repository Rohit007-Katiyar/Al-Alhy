using AhliFans.Core.Feature.Admin.Profile.Modify.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Profile.Modify;

public class ModifyEndPoint : EndpointBaseAsync
  .WithRequest<ModifyRequest>
  .WithActionResult
{

  private readonly IMediator _mediator;

  public ModifyEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(ModifyRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Modify his Profile Data",
    Description = "Admin Modify his Profile Data in Al-Ahly",
    OperationId = "Admin.ModifyProfile",
    Tags = new[] { "Account Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm] ModifyRequest request,
    CancellationToken cancellationToken = default)
    => await _mediator.Send(
      new ModifyEvent(request.FullName, request.EmailAddress, request.MobileNumber), cancellationToken);
}
