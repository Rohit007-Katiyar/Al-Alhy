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

namespace AhliFans.Core.Feature.Admin.MomentVideo.ChangeStatus.Events;
public class ChangeMomentVideoEventHandler : IRequestHandler<ChangeMomentVideoStatusEvent, ActionResult>
{
  private readonly IRepository<Entities.MomentVideo> _MomentVideoRepository;

  public ChangeMomentVideoEventHandler(IRepository<Entities.MomentVideo> MomentVideoRepository)
  {
    _MomentVideoRepository = MomentVideoRepository;
  }
  public async Task<ActionResult> Handle(ChangeMomentVideoStatusEvent request, CancellationToken cancellationToken)
  {
    var video = await _MomentVideoRepository.GetByIdAsync(request.MomentVideoId, cancellationToken);
    if (video is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    video.IsDeleted = !video.IsDeleted;
    video.ModifiedById = Guid.Parse(request.AdminId);
    video.ModifiedOn = DateTime.Now;
    await _MomentVideoRepository.UpdateAsync(video, cancellationToken);
    await _MomentVideoRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(video.IsDeleted ? "Delete Video Done You Can Retrieve It Any Time" : "Retrieve Video Done You Can Delete It Any Time", ResponseStatus.Success));
  }
}
