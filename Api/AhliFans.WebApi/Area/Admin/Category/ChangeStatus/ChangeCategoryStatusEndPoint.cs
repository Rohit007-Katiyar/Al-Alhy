using System.Security.Claims;
using AhliFans.Core.Feature.Admin.Category.ChangeStatus.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Category.ChangeStatus;

public class ChangeCategoryStatusEndPoint : EndpointBaseAsync
  .WithRequest<ChangeCategoryStatusRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ChangeCategoryStatusEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPatch(ChangeCategoryStatusRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
   Summary = "Admin Change Status Category",
   Description = "Admin Delete/Retrieve Category",
   OperationId = "Admin.ChangeCategoryJersey",
   Tags = new[] { "Category Endpoints" })
 ]
  public override async Task<ActionResult> HandleAsync([FromQuery] ChangeCategoryStatusRequest request, CancellationToken cancellationToken = default)
  {
    return await _mediator.Send(new ChangeCategoryStatusEvent(request.CategoryId, User.FindFirstValue("User Id")), cancellationToken);
  }
}
