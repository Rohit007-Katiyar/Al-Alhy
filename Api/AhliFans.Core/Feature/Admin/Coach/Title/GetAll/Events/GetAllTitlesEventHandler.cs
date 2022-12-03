using AhliFans.Core.Feature.Admin.Coach.Title.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Coach.Title.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Title.GetAll.Events;
public class GetAllTitlesEventHandler : IRequestHandler<GetAllTitlesEvent,ActionResult>
{
  private readonly IRepository<Entities.Title> _titleRepository;
  public GetAllTitlesEventHandler(IRepository<Entities.Title> titleRepository)
  {
    _titleRepository = titleRepository;
  }
  public async Task<ActionResult> Handle(GetAllTitlesEvent request, CancellationToken cancellationToken)
  {
    var titles = await _titleRepository.ListAsync(new GetAllTitles(request.PageIndex,request.PageSize,request.SearchWord,request.RequestIsDeleted),cancellationToken);
    if (titles.Count == 0) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(titles.Select(t => new TitlesDto(t.Id, request.Lang == Languages.En ? t.Text : t.TextAr,t.IsDeleted)));
  }
}
