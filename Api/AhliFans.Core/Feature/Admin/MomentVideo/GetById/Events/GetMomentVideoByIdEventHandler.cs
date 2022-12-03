using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.Core.Feature.Admin.MediaPhoto.GetById.Events;
using AhliFans.Core.Feature.Admin.MediaPhoto.GetById.Specification;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AhliFans.Core.Feature.Admin.MomentVideo.GetById.Specification;
using AhliFans.Core.Feature.Admin.MomentVideo.GetById.DTO;

namespace AhliFans.Core.Feature.Admin.MomentVideo.GetById.Events;
public class GetMomentVideoByIdEventHandler : IRequestHandler<GetMomentVideoByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.MomentVideo> _MomentVideoRepository;
  public GetMomentVideoByIdEventHandler(IRepository<Entities.MomentVideo> MomentVideoRepository)
  {
    _MomentVideoRepository = MomentVideoRepository;
  }

  public async Task<ActionResult> Handle(GetMomentVideoByIdEvent request, CancellationToken cancellationToken)
  {
    var video = await _MomentVideoRepository.GetBySpecAsync(new GetMomentVideoById(request.MomentVideoId), cancellationToken);
    if (video is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(new MomentVideoDetailsDto(video.Id, video.Season.Id,
      video.Season.StartDate.Year + "-" + video.Season?.EndDate?.Year,
      video.Month, video.VideoURL,
      video.Match.Id,
      video.League.Id,
      request.Lang == Languages.En ? video.League.Name : video.League.NameAr,
      video.Description, video.DescriptionAr,
      video.Player.Id,
      request.Lang == Languages.En ? video.Player.Name : video.Player.NameAr,
      video.VideoType, video.Time,
      video.Category.Id,
      request.Lang == Languages.En ? video.Category.Name : video.Category.NameAr,
      video.CreatedOn, video.ModifiedOn, video.IsDeleted,
      video.CreatedBy?.FullName, video.CreatedById, video.ModifiedBy?.FullName, video.ModifiedById
    ));
  }
}
