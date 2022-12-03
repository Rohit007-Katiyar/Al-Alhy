using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.Core.Feature.Admin.MediaPhoto.ChangeStatus.Events;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace AhliFans.Core.Feature.Admin.NormalVideo.ChangeStatus.Events;
public class ChangeNormalVideoEventHandler : IRequestHandler<ChangeNormalVideoStatusEvent, ActionResult>
{
  private readonly IRepository<Entities.NormalVideo> _normalVideoRepository;

  public ChangeNormalVideoEventHandler(IRepository<Entities.NormalVideo> normalVideoRepository)
  {
    _normalVideoRepository = normalVideoRepository;
  }
  public async Task<ActionResult> Handle(ChangeNormalVideoStatusEvent request, CancellationToken cancellationToken)
  {
    var video = await _normalVideoRepository.GetByIdAsync(request.normalVideoId, cancellationToken);
    if (video is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    video.IsDeleted = !video.IsDeleted;
    video.ModifiedById = Guid.Parse(request.AdminId);
    video.ModifiedOn = DateTime.Now;
    await _normalVideoRepository.UpdateAsync(video, cancellationToken);
    await _normalVideoRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(video.IsDeleted ? "Delete Video Done You Can Retrieve It Any Time" : "Retrieve Video Done You Can Delete It Any Time", ResponseStatus.Success));
  }
}
