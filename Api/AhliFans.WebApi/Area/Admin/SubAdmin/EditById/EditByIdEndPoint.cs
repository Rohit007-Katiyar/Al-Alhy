using AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.EditById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.SubAdmin;

public class EditByIdEndPoint :EndpointBaseAsync
  .WithRequest<EditByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(EditByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Super Admin Edit Other Admins Info",
    Description = "Super Admin Edit Other Admins Info",
    OperationId = "Admin.EditAdmins",
    Tags = new[] {"SubAdmin Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]EditByIdRequest request, CancellationToken cancellationToken = default) =>
    await _mediator.Send(new EditByIdEvent(request.AdminId,request.Name!,request.Email!,request.PhoneNumber!),
      cancellationToken);
}
