using AhliFans.Core.Feature.Fan.AppLanguage.Get.Dto;
using AhliFans.Core.Feature.Fan.AppLanguage.Get.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
 using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Account.AppLanguage.Get;

public class GetLanguageEndPoint : EndpointBaseAsync
  .WithoutRequest
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetLanguageEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetLanguageRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanLanguageDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get His App Language",
    Description = "Client Get His App Language",
    OperationId = "Client.GetLanguage",
    Tags = new[] { "Client Account Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default)
    => await _mediator.Send(new GetLanguageEvent(), cancellationToken);
}
