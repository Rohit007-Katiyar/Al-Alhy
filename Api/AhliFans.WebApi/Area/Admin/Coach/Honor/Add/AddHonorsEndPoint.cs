using AhliFans.Core.Feature.Admin.Coach.Honor.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Coach.Honor.Add;

public class AddHonorsEndPoint : EndpointBaseAsync
  .WithRequest<AddHonorsRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddHonorsEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(AddHonorsRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add Coach Honor",
    Description = "Admin Add Coach Honor",
    OperationId = "Admin.AddCoachHonor",
    Tags = new[] { "Coach Honor Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(AddHonorsRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddCoachHonorEvent(request.CoachId, request.TrophyId, request.IsPersonal),cancellationToken);
}
