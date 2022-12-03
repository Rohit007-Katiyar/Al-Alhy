
using AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.GetAll.Dto;
using AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.SubAdmin;

public class AdminsEndPoint : EndpointBaseAsync
  .WithRequest<AdminsRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AdminsEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(AdminsRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<AdminsDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Super Admin Get All Admin",
    Description = "Super Admin Get All Admin",
    OperationId = "Admin.AllAdmins",
    Tags = new[] { "SubAdmin Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] AdminsRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AdminsEvent(request.PageIndex, request.PageSize, request.IsBlocked, request.Name!, request.Email!,
        request.PhoneNumber!), cancellationToken);
}
