using System.Web;
using AhliFans.Core.Feature.Admin.Category;
using AhliFans.Core.Feature.Admin.Category.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Category.GetAll;

public class GetAllCategoryEndPoint : EndpointBaseAsync
  .WithRequest<GetAllCategoryRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllCategoryEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetAllCategoryRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<CategoryDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get All Category",
    Description = "Admin Get All Category",
    OperationId = "Admin.Category",
    Tags = new[] { "Category Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetAllCategoryRequest request,
   CancellationToken cancellationToken = default)
  {
    var decodedWord = HttpUtility.UrlDecode(request.SearchWord);
    return await _mediator.Send(new GetAllCategoryEvent(request.PageIndex, request.PageSize, decodedWord, request.IsDeleted, request.Type, request.Lang),
      cancellationToken);
  }
}
