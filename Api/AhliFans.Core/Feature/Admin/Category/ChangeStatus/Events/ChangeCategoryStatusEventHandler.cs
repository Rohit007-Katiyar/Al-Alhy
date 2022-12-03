using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.Core.Feature.Admin.Season.ChangeStatus.Events;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AhliFans.Core.Feature.Entities;

namespace AhliFans.Core.Feature.Admin.Category.ChangeStatus.Events;
public class ChangeCategoryStatusEventHandler : IRequestHandler<ChangeCategoryStatusEvent, ActionResult>
{
  private readonly IRepository<Entities.Category> _categoryRepository;

  public ChangeCategoryStatusEventHandler(IRepository<Entities.Category> categoryRepository)
  {
    _categoryRepository = categoryRepository;
  }

  public async Task<ActionResult> Handle(ChangeCategoryStatusEvent request, CancellationToken cancellationToken)
  {
    var category = await _categoryRepository.GetByIdAsync(request.categoryId, cancellationToken);
    if (category is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    category.IsDeleted = !category.IsDeleted;
    category.ModifiedById = Guid.Parse(request.AdminId);
    category.ModifiedOn = DateTime.Now;
    await _categoryRepository.UpdateAsync(category, cancellationToken);
    await _categoryRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(category.IsDeleted ? "Delete Category Done You Can Retrieve It Any Time" : "Retrieve Category Done You Can Delete It Any Time", ResponseStatus.Success));
  }

}
