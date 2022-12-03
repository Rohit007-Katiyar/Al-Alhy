using AhliFans.Core.Feature.Admin.Trophy.TrophyType.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Trophy.TrophyType;

public class AddEndPoint : EndpointBaseAsync
  .WithRequest<AddRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPost(AddRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add New Trophy Type",
    Description = "Admin Add New Trophy Type",
    OperationId = "Admin.AddTrophyType",
    Tags = new[] { "Trophy Type Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(AddRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddTrophyTypeEvent(request.Name, request.NameAr), cancellationToken);
}
