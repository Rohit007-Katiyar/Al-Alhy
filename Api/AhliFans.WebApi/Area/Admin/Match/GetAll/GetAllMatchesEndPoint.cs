using AhliFans.Core.Feature.Admin.Match.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Match.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Match;

public class GetAllMatchesEndPoint :EndpointBaseAsync
  .WithRequest<GetAllMatchesRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllMatchesEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetAllMatchesRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MatchesDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get All Match",
    Description = "Admin Get All Match",
    OperationId = "Admin.AllMatch",
    Tags = new[] {"Match Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllMatchesRequest request,
    CancellationToken cancellationToken = default)
    => await _mediator.Send(new GetAllMatchesEvent(request.PageIndex, request.PageSize, request.LeagueId,
      request.LeagueDataId, request.Lang,request.IsDeleted,request.IsAvailable,request.MatchTypes),cancellationToken);
}
