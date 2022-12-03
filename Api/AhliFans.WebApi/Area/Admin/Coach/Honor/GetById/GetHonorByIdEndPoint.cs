using AhliFans.Core.Feature.Admin.Coach.Honor.GetById.DTO;
using AhliFans.Core.Feature.Admin.Coach.Honor.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Coach.Honor.GetById;

public class GetHonorByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetHonorByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetHonorByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetHonorByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CoachHonorDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get By Id Coach Honor",
    Description = "Admin Get By Id Coach Honor",
    OperationId = "Admin.GetByIdCoachHonor",
    Tags = new[] { "Coach Honor Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetHonorByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetHonorByIdEvent(request.HonorId,request.Lang), cancellationToken);
}
