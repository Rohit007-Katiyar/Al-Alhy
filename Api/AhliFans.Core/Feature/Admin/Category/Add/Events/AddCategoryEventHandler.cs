using AhliFans.Core.Feature.Admin.Category.Add.Specifications;
using AhliFans.Core.Feature.Admin.Season.Add.Events;
using AhliFans.Core.Feature.Admin.Season.Add.Specifications;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Category.Add.Events;
public class AddCategoryEventHandler : IRequestHandler<AddCategoryEvent, ActionResult>
{
  private readonly IRepository<Entities.Category> _categoryRepository;
  private readonly IMapper _mapper;
  public AddCategoryEventHandler(IRepository<Entities.Category> categoryRepository, IMapper mapper)
  {
    _categoryRepository = categoryRepository;
    _mapper = mapper;
  }

  public async Task<ActionResult> Handle(AddCategoryEvent request, CancellationToken cancellationToken)
  {
    var category = _mapper.Map<Entities.Category>(request);
    if (await _categoryRepository.AnyAsync(new IsCategoryExist(0,request.Name, request.NameAr), cancellationToken))
    {
      return new BadRequestObjectResult(new AdminResponse("Sorry,same category exist already!", ResponseStatus.Error));
    }
    await _categoryRepository.AddAsync(category, cancellationToken);
    await _categoryRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
}
