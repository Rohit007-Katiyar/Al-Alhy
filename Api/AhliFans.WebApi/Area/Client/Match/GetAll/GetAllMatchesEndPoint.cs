using AhliFans.Core.Feature.Fan.Match.GetAll.DTO;
using AhliFans.Core.Feature.Fan.Match.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Match.GetAll;

public class GetAllMatchesEndPoint :EndpointBaseAsync
  .WithRequest<GetAllMatchesRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllMatchesEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetAllMatchesRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MatchesDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get All Match",
    Description = "Client Get All Match",
    OperationId = "Client.AllMatch",
    Tags = new[] {"Match Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllMatchesRequest request,
    CancellationToken cancellationToken = default)
    => await _mediator.Send(new GetAllMatchesEvent(request.PageIndex, request.PageSize, request.LeagueId,
      request.LeagueDataId,request.MatchType, request.Lang),cancellationToken);
}
