using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Title.ChangeStatus.Events;
public class ChangeStatusEventHandler : IRequestHandler<ChangeTitleStatusEvent, ActionResult>
{
  private readonly IRepository<Entities.Title> _titleRepository;

  public ChangeStatusEventHandler(IRepository<Entities.Title> titleRepository)
  {
    _titleRepository = titleRepository;
  }
  public async Task<ActionResult> Handle(ChangeTitleStatusEvent request, CancellationToken cancellationToken)
  {
    var title = await _titleRepository.GetByIdAsync(request.TitleId, cancellationToken);
    if (title is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    title.IsDeleted = !title.IsDeleted;
    await _titleRepository.UpdateAsync(title, cancellationToken);
    await _titleRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(title.IsDeleted ? "Delete Title Done You Can Retrieve It Any Time" : "Retrieve Title Done You Can Delete It Any Time", ResponseStatus.Success));
  }

}
