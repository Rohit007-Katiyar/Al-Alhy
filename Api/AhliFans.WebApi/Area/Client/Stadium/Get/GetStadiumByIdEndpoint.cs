using AhliFans.Core;
using AhliFans.Core.Feature.Fan.Stadium.Get.Dto;
using AhliFans.Core.Feature.Fan.Stadium.Get.Events;
using AhliFans.Core.Feature.Security.Enums;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Stadium;

public class GetStadiumByIdEndpoint : EndpointBaseAsync
.WithRequest<GetStadiumByIdRequest>
.WithActionResult
{
  private readonly IMediator _mediator;

  public GetStadiumByIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetStadiumByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StadiumDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]  
  [SwaggerOperation(
    Summary = "Fan get stadium",
    Description = "Fan get stadium by stadium id",
    OperationId = "Client.GetStadium",
    Tags = new[] { "Stadium Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetStadiumByIdRequest request, CancellationToken cancellationToken = default)
  {
    return await _mediator.Send(new GetStadiumByIdEvent(request.StadiumId, request.Language), cancellationToken);
  }
}
