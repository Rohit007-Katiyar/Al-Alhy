using AhliFans.Core.Feature.Admin.Coach.Honor.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Coach.Honor.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Coach.Honor.GetAll;

public class GetAllCoachHonorsEndPoint : EndpointBaseAsync
  .WithRequest<GetAllCoachHonorsRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllCoachHonorsEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetAllCoachHonorsRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<CoachHonorsDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get All Coach Honors",
    Description = "Admin Get All Coach Honors",
    OperationId = "Admin.GetAllCoachHonor",
    Tags = new[] { "Coach Honor Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllCoachHonorsRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllCoachHonorsEvent(request.CoachId, request.Lang, request.PageIndex, request.PageSize,
      request.IsDeleted), cancellationToken);
}
