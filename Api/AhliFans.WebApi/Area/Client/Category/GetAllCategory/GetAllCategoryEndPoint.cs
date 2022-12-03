
using AhliFans.Core.Feature.Fan.Category.GetAll.DTO;
using AhliFans.Core.Feature.Fan.Category.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Category.GetAllCategory;

public class GetAllCategoryEndPoint : EndpointBaseAsync
  .WithRequest<GetAllCategoryRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllCategoryEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [AllowAnonymous]
  [HttpGet(GetAllCategoryRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<CategoryFanDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client get all Category",
    Description = "List of ALl Category In Arabic or English",
    OperationId = "Client.GetAllCategory",
    Tags = new[] { "Category Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetAllCategoryRequest request,
    CancellationToken cancellationToken = default) =>
      await _mediator.Send(new GetAllCategoryEvent(request.PageIndex, request.PageSize, request.IsDeleted, request.Lang),
          cancellationToken);

}
