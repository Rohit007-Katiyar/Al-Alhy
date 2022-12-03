using AhliFans.Core.Feature.Fan.VotePanel.Moment.GetAll.DTO;
using AhliFans.Core.Feature.Fan.VotePanel.Moment.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.VotePanel.Moment.GetAll;

public class GetAllMomentsEndPoint : EndpointBaseAsync
  .WithRequest<GetAllMomentsRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllMomentsEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetAllMomentsRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MomentDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client GetAll Moments",
    Description = "Client GetAll Moments",
    OperationId = "Client.GetAllMoments",
    Tags = new[] {"Vote Engine Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllMomentsRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllMomentsEvent(request.PageIndex, request.PageSize, request.MomentType,request.Lang),
      cancellationToken);
}
