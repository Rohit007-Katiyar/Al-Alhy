using AhliFans.Core.Feature.Admin.Category.GetById.DTO;
using AhliFans.Core.Feature.Admin.Category.GetById.Specification;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Category.GetById.Events;
public class GetNormalVideoByIdEventHandler : IRequestHandler<GetCategoryByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.Category> _categoryRepository;

  public GetNormalVideoByIdEventHandler(IRepository<Entities.Category> categoryRepository)
  {
    _categoryRepository = categoryRepository;
  }

  public async Task<ActionResult> Handle(GetCategoryByIdEvent request, CancellationToken cancellationToken)
  {
    var category = await _categoryRepository.GetBySpecAsync(new GetCategoryById(request.CategoryId), cancellationToken);
    if (category is null)
      return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(new CategoryDetailsDto(category.Id, category.Name, category.NameAr, category.Description, category.DescriptionAr,
      category.photo ?? false,
      category.video ?? false,
      category.otd ?? false,
      category.CreatedOn, category.ModifiedOn, category.IsDeleted, category.CreatedBy?.FullName, category.CreatedById, category.ModifiedBy?.FullName, category.ModifiedById));
  }
}
