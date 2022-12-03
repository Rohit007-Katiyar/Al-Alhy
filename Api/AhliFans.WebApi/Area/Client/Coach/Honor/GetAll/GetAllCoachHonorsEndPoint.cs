using AhliFans.Core.Feature.Fan.Coach.Honor.GetAll.DTO;
using AhliFans.Core.Feature.Fan.Coach.Honor.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Coach.Honor.GetAll;

public class GetAllCoachHonorsEndPoint : EndpointBaseAsync
  .WithRequest<GetAllCoachHonorsRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllCoachHonorsEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetAllCoachHonorsRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<CoachHonorsDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Client Get All Coach Honors",
    Description = "Client Get All Coach Honors",
    OperationId = "Client.GetAllCoachHonor",
    Tags = new[] { "Coach Honor Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllCoachHonorsRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllCoachHonorsEvent(request.CoachId,request.TrophyTypeId, request.Lang, request.PageIndex, request.PageSize,
      request.IsDeleted), cancellationToken);
}
