using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AhliFans.Core.Feature.Admin.MediaPhoto.GetById.DTO;
using AhliFans.Core.Feature.Admin.MediaPhoto.GetById.Specification;
using AhliFans.Core.Feature.Entities;
using System.Xml.Linq;

namespace AhliFans.Core.Feature.Admin.MediaPhoto.GetById.Events;
public class GetPhotoByIdEventHandler : IRequestHandler<GetPhotoByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.MediaPhoto> _photoRepository;
  public GetPhotoByIdEventHandler(IRepository<Entities.MediaPhoto> photoRepository)
  {
    _photoRepository = photoRepository;
  }

  public async Task<ActionResult> Handle(GetPhotoByIdEvent request, CancellationToken cancellationToken)
  {
    var photo = await _photoRepository.GetBySpecAsync(new GetPhotoById(request.PhotoId), cancellationToken);
    if (photo is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(new PhotoDetailsDto(photo.Id, $"{photo.Id}/{photo.Photo}", photo.Season.Id,
      photo.Season.StartDate.Year + "-" + photo.Season?.EndDate?.Year,
      photo.Month,photo.PhotoLink,
      photo.Match?.Id??0,
      photo.League.Id,
      request.Lang == Languages.En ? photo.League.Name : photo.League.NameAr,
      photo.Description, 
      photo.DescriptionAr, 
      photo?.Player.Id,
      request.Lang == Languages.En ? photo?.Player.Name : photo?.Player.NameAr,
      photo?.Coach.Id,
      request.Lang == Languages.En ? photo?.Coach.FirstName+' '+photo?.Coach.LastName : photo?.Coach.FirstNameAr + ' ' + photo?.Coach.LastNameAr,
      photo.Category.Id,
      request.Lang == Languages.En ? photo.Category.Name : photo.Category.NameAr,
      photo?.IsExclusiveContent,
      photo.CreatedOn, photo.ModifiedOn, photo.IsDeleted,
      photo.CreatedBy?.FullName, photo.CreatedById, photo.ModifiedBy?.FullName, photo.ModifiedById
    ));
  }
}

