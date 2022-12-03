using AhliFans.Core.Feature.Admin.Coach.Title.GetById.DTO;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Title.GetById.Events;

public class GetByIdEventHandler : IRequestHandler<GetTitleByIdEvent,ActionResult>
{
  private readonly IRepository<Entities.Title> _titleRepository;

  public GetByIdEventHandler(IRepository<Entities.Title> titleRepository)
  {
    _titleRepository = titleRepository;
  }
  public async Task<ActionResult> Handle(GetTitleByIdEvent request, CancellationToken cancellationToken)
  {
    var title = await _titleRepository.GetByIdAsync(request.TitleId,cancellationToken);
    if (title is null) return new BadRequestObjectResult(new AdminResponse("Not Found",ResponseStatus.Error));
    return new OkObjectResult(new TitleDto(title.Id, title.IsDeleted, title.Text, title.TextAr));
  }
}
