using AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Player.SocialMediaAccounts.GetAll;

public class GetAllEntPoint : EndpointBaseAsync
  .WithRequest<GetAllRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllEntPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetAllRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<AdminPlayerAccountsDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Player Accounts",
    Description = "Admin Get Player Accounts",
    OperationId = "Admin.GetPlayerAccounts",
    Tags = new[] {"Player Social Media Accounts Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllPlayerAccountsEvent(request.PlayerId,request.IsDeleted),cancellationToken);
}
