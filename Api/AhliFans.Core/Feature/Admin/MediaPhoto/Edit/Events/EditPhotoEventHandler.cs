using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.Core.Feature.Admin.Coach.Update.Events;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AhliFans.Core.Feature.Entities;

namespace AhliFans.Core.Feature.Admin.MediaPhoto.Edit.Events;
public class EditPhotoEventHandler : IRequestHandler<EditPhotoEvent, ActionResult>
{
  private readonly IRepository<Entities.MediaPhoto> _photoRepository;
  public EditPhotoEventHandler(IRepository<Entities.MediaPhoto> photoRepository)
  {
    _photoRepository = photoRepository;
  }

  public async Task<ActionResult> Handle(EditPhotoEvent request, CancellationToken cancellationToken)
  {
    var photo = await _photoRepository.GetByIdAsync(request.PhotoId, cancellationToken);
    if (photo is null) return new BadRequestObjectResult(new AdminResponse("Not Found", ResponseStatus.Error));
    
    MapPhoto(request, ref photo);
    await _photoRepository.UpdateAsync(photo, cancellationToken);
    await _photoRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully.", ResponseStatus.Success));
  }

  private static void MapPhoto(EditPhotoEvent request, ref Entities.MediaPhoto photo)
  {
    photo.SeasonId = request.SeasonId == 0 ? photo.SeasonId : request.SeasonId;
    photo.Month = string.IsNullOrEmpty(request.Month) ? photo.Month : request.Month;
    photo.PhotoLink = string.IsNullOrEmpty(request.PhotoLink) ? photo.PhotoLink : request.PhotoLink;
    photo.MatchId = request.MatchId == 0 ? photo.MatchId : request.MatchId;
    photo.LeagueId = request.LeagueId == 0 ? photo.LeagueId : request.LeagueId;
    photo.Description = string.IsNullOrEmpty(request.Description) ? photo.Description : request.Description;
    photo.DescriptionAr = string.IsNullOrEmpty(request.DescriptionAr) ? photo.DescriptionAr : request.DescriptionAr;
    photo.PlayerId = request.PlayerId == 0 ? photo.PlayerId : request.PlayerId;
    photo.CoachId = request.CoachId == 0 ? photo.CoachId : request.CoachId;
    photo.CategoryId = request.CategoryId == 0 ? photo.CategoryId : request.CategoryId;
    photo.IsExclusiveContent = request.IsExclusiveContent;
    photo.ModifiedById = Guid.Parse(request.AdminId);
    photo.ModifiedOn = DateTime.Now;

  }
}
