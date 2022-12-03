using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AhliFans.Core.Feature.Admin.Category.GetAll.Specification;


namespace AhliFans.Core.Feature.Admin.Category.GetAll.Events;
public class GetAllCategoryEventHandler : IRequestHandler<GetAllCategoryEvent, ActionResult>
{
  private readonly IRepository<Entities.Category> _categoryRepository;
  public GetAllCategoryEventHandler(IRepository<Entities.Category> categoryRepository)
  {
    _categoryRepository = categoryRepository;
  }

  public async Task<ActionResult> Handle(GetAllCategoryEvent request, CancellationToken cancellationToken)
  {
    var category = await _categoryRepository.ListAsync(new GetAllCategories(request.PageIndex, request.PageSize, request.SearchWord, request.IsDeleted, request.type),
      cancellationToken);
    if (category.Count == 0) new OkObjectResult(new AdminResponse("No Data yet", ResponseStatus.Error));

    return new OkObjectResult(category.Select(j => new CategoryDto(
      j.Id, request.Lang == Languages.En ? j.Name : j.NameAr,
      request.Lang == Languages.En ? j.Description : j.DescriptionAr,
       j.photo ?? false,
       j.video ?? false,
       j.otd ?? false,
      j.CreatedOn, j.ModifiedOn,
      j.IsDeleted,
      j.CreatedBy?.FullName!,
      j.CreatedById,
      j.ModifiedBy?.FullName!,
      j.ModifiedById)));
  }
}
