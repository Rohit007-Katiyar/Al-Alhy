using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Title.Edit.Events;
public class EditTitleEventHandler : IRequestHandler<EditTitleEvent,ActionResult>
{
  private readonly IRepository<Entities.Title> _titleRepository;
  public EditTitleEventHandler(IRepository<Entities.Title> titleRepository)
  {
    _titleRepository = titleRepository;
  }
  public async Task<ActionResult> Handle(EditTitleEvent request, CancellationToken cancellationToken)
  {
    var titel = await _titleRepository.GetByIdAsync(request.TitleId,cancellationToken);
    if (titel is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    titel.Text = request.Text ?? titel.Text;
    titel.TextAr = request.TextAr ?? titel.TextAr;

    await _titleRepository.UpdateAsync(titel,cancellationToken);
    await _titleRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation don successfully", ResponseStatus.Success));
  }
}
