using AhliFans.Core.Feature.Fan.Category.GetAll.DTO;
using AhliFans.Core.Feature.Fan.Category.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using AhliFans.WebApi.Area.Client.Category.GetAllCategory;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Category.GetByCategoryId;

public class GetByCategoryIdEndPoint : EndpointBaseAsync
  .WithRequest<GetByCategoryIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetByCategoryIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetByCategoryIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<CategoryFanDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client get Category by Id",
    Description = "List of Category In Arabic or English",
    OperationId = "Client.GetByCategoryId",
    Tags = new[] { "CategoryId Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetByCategoryIdRequest request,
    CancellationToken cancellationToken = default) =>
      await _mediator.Send(new GetByCategoryIdEvent(request.PageIndex, request.PageSize, request.CategoryId, request.Lang),
          cancellationToken);

}
