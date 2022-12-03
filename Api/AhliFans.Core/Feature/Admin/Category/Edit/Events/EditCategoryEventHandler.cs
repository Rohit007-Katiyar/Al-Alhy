using AhliFans.Core.Feature.Admin.Category.Add.Specifications;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Category.Edit.Events;
public class EditCategoryEventHandler : IRequestHandler<EditCategoryEvent, ActionResult>
{
  private readonly IRepository<Entities.Category> _categoryRepository;
  public EditCategoryEventHandler(IRepository<Entities.Category> categoryRepository)
  {
    _categoryRepository = categoryRepository;
  }

  public async Task<ActionResult> Handle(EditCategoryEvent request, CancellationToken cancellationToken)
  {
    var category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);
    if (category == null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    if (await _categoryRepository.AnyAsync(new IsCategoryExist(request.CategoryId, request.Name, request.NameAr), cancellationToken))
    {
      return new BadRequestObjectResult(new AdminResponse("Sorry,same category exist already!", ResponseStatus.Error));
    }

    category.Name = request.Name ?? category.Name;
    category.NameAr = request.NameAr ?? category.NameAr;
    category.Description = request.Description ?? category.Description;
    category.DescriptionAr = request.DescriptionAr ?? category.DescriptionAr;
    category.photo = request.photo;
    category.video = request.video;
    category.otd = request.otd;
    category.ModifiedById = Guid.Parse(request.AdminId);
    category.ModifiedOn = DateTime.Now;
    await _categoryRepository.UpdateAsync(category, cancellationToken);
    await _categoryRepository.SaveChangesAsync(cancellationToken);
    
    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
}
