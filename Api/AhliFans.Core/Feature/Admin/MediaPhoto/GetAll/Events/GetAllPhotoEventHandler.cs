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
using AhliFans.Core.Feature.Admin.MediaPhoto.GetAll.Specification;
using AhliFans.Core.Feature.Admin.MediaPhoto.GetAll.DTO;

namespace AhliFans.Core.Feature.Admin.MediaPhoto.GetAll.Events;
public class GetAllPhotoEventHandler : IRequestHandler<GetAllPhotoEvent, ActionResult>
{
  private readonly IRepository<Entities.MediaPhoto> _photoRepository;
  public GetAllPhotoEventHandler(IRepository<Entities.MediaPhoto> photoRepository)
  {
    _photoRepository = photoRepository;
  }
  public async Task<ActionResult> Handle(GetAllPhotoEvent request, CancellationToken cancellationToken)
  {
    var photo = await _photoRepository.ListAsync(new GetAllPhotos(request.PageIndex, request.PageSize, request.SearchWord!, request.IsDeleted), cancellationToken);
    if (photo.Count == 0) return new OkObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(photo.Select(c => new PhotoDto(c.Id, $"{c.Id}/{c.Photo}", c.Month, c.PhotoLink, 
       request.Lang == Languages.En ? c.Description : c.DescriptionAr,
       //request.Lang == Languages.En ? (c.IsExclusiveContent==true? "true":"false"): (c.IsExclusiveContent == true ? "true" : "false"),
       c.IsExclusiveContent??false,
        c.Season.StartDate.Year+"-" + c.Season?.EndDate?.Year,
       c.MatchId,
       request.Lang == Languages.En ? c.League.Name : c.League.NameAr,
       request.Lang == Languages.En ? c.Player.Name : c.Player.NameAr,
       request.Lang == Languages.En ? c.Coach.FirstName+' '+ c.Coach.LastName : c.Coach.FirstNameAr+' '+c.Coach.LastNameAr,
       request.Lang == Languages.En ? c.Category?.Name??string.Empty : c.Category?.NameAr??string.Empty,
      c.CreatedOn, c.ModifiedOn, c.IsDeleted, c.CreatedBy?.FullName!, c.CreatedById, c.ModifiedBy?.FullName!, c.ModifiedById)));
  }
}
