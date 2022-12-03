using AhliFans.Core.Feature.Fan.Coach.Honor.GetById.DTO;
using AhliFans.Core.Feature.Fan.Coach.Honor.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Coach.Honor.GetById;

public class GetHonorByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetHonorByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetHonorByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetHonorByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CoachHonorDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Client Get By Id Coach Honor",
    Description = "Client Get By Id Coach Honor",
    OperationId = "Client.GetByIdCoachHonor",
    Tags = new[] { "Coach Honor Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetHonorByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetHonorByIdEvent(request.HonorId,request.Lang), cancellationToken);
}
