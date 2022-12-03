using AhliFans.Core;
using AhliFans.Core.Feature.Fan.VotePanel.Player;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.VotePanel.Player;

public class GetVoteEndpoint : EndpointBaseAsync
  .WithRequest<GetVoteRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetVoteEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize(nameof(Roles.Fan))]
  [HttpGet(GetVoteRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientVoteDetailsDto))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [SwaggerOperation(
    Summary = "Client get his player vote",
    Description = "Client get his player vote",
    OperationId = "Client.ClientGetVote",
    Tags = new[] { "Vote Engine Endpoints" })
  ]

  public override async Task<ActionResult> HandleAsync([FromQuery]GetVoteRequest request, CancellationToken cancellationToken = new CancellationToken())
  {
    var ev = new GetClientVoteEvent(request.Lang ?? Languages.Ar);
    return await _mediator.Send(ev, cancellationToken);
  }
}
