using AhliFans.Core.Feature.Admin.Match.GetById.DTO;
using AhliFans.Core.Feature.Admin.Match.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Match;

public class GetMatchByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetMatchByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetMatchByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  //[Authorize]
  [HttpGet(GetMatchByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MatchDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Match By Id",
    Description = "Admin Get Match By Id",
    OperationId = "Admin.GetMatchById",
    Tags = new[] { "Match Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetMatchByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetMatchByIdEvent(request.MatchId,request.Lang),cancellationToken);
}
