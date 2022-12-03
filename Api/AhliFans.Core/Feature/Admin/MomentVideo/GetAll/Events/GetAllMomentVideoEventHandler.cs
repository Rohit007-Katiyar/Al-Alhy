using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.Core.Feature.Admin.MediaPhoto.GetAll.Events;
using AhliFans.Core.Feature.Admin.MediaPhoto.GetAll.Specification;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AhliFans.Core.Feature.Admin.MomentVideo.GetAll.Specification;
using AhliFans.Core.Feature.Admin.MomentVideo.GetAll.DTO;

namespace AhliFans.Core.Feature.Admin.MomentVideo.GetAll.Events;
public class GetAllMomentVideoEventHandler : IRequestHandler<GetAllMomentVideoEvent, ActionResult>
{
  private readonly IRepository<Entities.MomentVideo> _MomentVideoRepository;
  public GetAllMomentVideoEventHandler(IRepository<Entities.MomentVideo> MomentVideoRepository)
  {
    _MomentVideoRepository = MomentVideoRepository;
  }
  public async Task<ActionResult> Handle(GetAllMomentVideoEvent request, CancellationToken cancellationToken)
  {
    var photo = await _MomentVideoRepository.ListAsync(new GetAllMomentVideo(request.PageIndex, request.PageSize, request.SearchWord!, request.IsDeleted), cancellationToken);
    if (photo.Count == 0) return new OkObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(photo.Select(c => new MomentVideoDto(c.Id, c.Month, c.VideoURL,
       request.Lang == Languages.En ? c.Description : c.DescriptionAr,
       c.Season.StartDate.Year + "-" + c.Season?.EndDate?.Year,
       c.MatchId??0,
       request.Lang == Languages.En ? c.League.Name : c.League.NameAr,
       request.Lang == Languages.En ? c.Player.Name : c.Player.NameAr,
       c.VideoType,c.Time,
       request.Lang == Languages.En ? c.Category.Name : c.Category.NameAr,
      c.CreatedOn, c.ModifiedOn, c.IsDeleted, c.CreatedBy?.FullName!, c.CreatedById, c.ModifiedBy?.FullName!, c.ModifiedById)));
  }
}
