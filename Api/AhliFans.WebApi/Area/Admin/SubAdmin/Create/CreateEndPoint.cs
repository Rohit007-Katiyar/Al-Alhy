using AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.Create.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.SubAdmin;

public class CreateEndPoint : EndpointBaseAsync
  .WithRequest<CreateRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public CreateEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPost(CreateRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Super Admin Add New Admin",
    Description = "Super Admin Add New Admin",
    OperationId = "Admin.AddSubAdmin",
    Tags = new[] { "SubAdmin Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromBody]CreateRequest request,
    CancellationToken cancellationToken = default) => await _mediator.Send(
    new CreateEvent(request.FullName, request.Email, request.Password, request.ConfirmPassword, request.PhoneNumber),
    cancellationToken);
}
