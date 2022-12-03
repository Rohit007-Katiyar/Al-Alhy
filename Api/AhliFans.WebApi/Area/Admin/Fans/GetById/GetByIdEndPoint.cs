using AhliFans.Core.Feature.Admin.ManageUsers.Fan.GetById.DTO;
using AhliFans.Core.Feature.Admin.ManageUsers.Fan.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Fans;

public class GetByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [AllowAnonymous]
  [HttpGet(GetByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin get Fan by id",
    Description = "Admin get Fan by id",
    OperationId = "Admin.GetFan",
    Tags = new[] { "Fans Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute]GetByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetFanByIdEvent(request.FanId), cancellationToken);
}
