using AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.GetAll.DTO;
using AhliFans.Core.Feature.Fan.Player.SocialMediaAccounts.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using AhliFans.WebApi.Client.Admin.Player.SocialMediaAccounts.GetAll;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Player.SocialMediaAccounts.GetAll;

public class GetAllEntPoint : EndpointBaseAsync
  .WithRequest<GetAllAccountsRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllEntPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetAllAccountsRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<AdminPlayerAccountsDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get Player Accounts",
    Description = "Client Get Player Accounts",
    OperationId = "Client.GetPlayerAccounts",
    Tags = new[] { "Player Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetAllAccountsRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllPlayerAccountsEvent(request.PlayerId),cancellationToken);
}
