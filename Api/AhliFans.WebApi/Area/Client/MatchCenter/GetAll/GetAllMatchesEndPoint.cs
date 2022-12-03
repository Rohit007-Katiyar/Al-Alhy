﻿using AhliFans.Core.Feature.Fan.MatchCenter.Match;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.MatchCenter.GetAll;

public class GetAllMatchesEndPoint : EndpointBaseAsync
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
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MatchCenterDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get Matches Of Match Center",
    Description = "Client Get Match Of Match Center",
    OperationId = "Client.AllCenterMatch",
    Tags = new[] { "Match Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllMatchesRequest request,
    CancellationToken cancellationToken = default) => await _mediator.Send(new GetAllMatchesEvent(request.PageIndex, 
    request.PageSize, request.MatchType, request.Lang),cancellationToken);
}
