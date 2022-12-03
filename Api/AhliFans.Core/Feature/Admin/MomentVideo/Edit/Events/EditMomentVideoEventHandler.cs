using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AhliFans.Core.GenerateThumbnail;

namespace AhliFans.Core.Feature.Admin.MomentVideo.Edit.Events;
public class EditMomentVideoEventHandler : IRequestHandler<EditMomentVideoEvent, ActionResult>
{
  private readonly IRepository<Entities.MomentVideo> _MomentVideoRepository;
  public EditMomentVideoEventHandler(IRepository<Entities.MomentVideo> MomentVideoRepository)
  {
    _MomentVideoRepository = MomentVideoRepository;
  }

  public async Task<ActionResult> Handle(EditMomentVideoEvent request, CancellationToken cancellationToken)
  {
    var video = await _MomentVideoRepository.GetByIdAsync(request.MomentVideoId, cancellationToken);
    if (video is null) return new BadRequestObjectResult(new AdminResponse("Not Found", ResponseStatus.Error));

    var updateThumbnail = request.VideoURL.Equals(video.VideoURL);

    MapVideo(request, ref video);

    await _MomentVideoRepository.UpdateAsync(video, cancellationToken);
    await _MomentVideoRepository.SaveChangesAsync(cancellationToken);

    if (!updateThumbnail)
    {
      var fileName = "momentvideo_" + video.Id;
      ImageUtility.SaveThumbnail(request.VideoURL, fileName, "MomentVideo");
    }
    return new OkObjectResult(new AdminResponse("Operation done successfully.", ResponseStatus.Success));
  }

  private static void MapVideo(EditMomentVideoEvent request, ref Entities.MomentVideo video)
  {
    video.SeasonId = request.SeasonId == 0 ? video.SeasonId : request.SeasonId;
    video.Month = string.IsNullOrEmpty(request.Month) ? video.Month : request.Month;
    video.VideoURL = string.IsNullOrEmpty(request.VideoURL) ? video.VideoURL : request.VideoURL;
    video.MatchId = request.MatchId == 0 ? video.MatchId : request.MatchId;
    video.LeagueId = request.LeagueId == 0 ? video.LeagueId : request.LeagueId;
    video.Description = string.IsNullOrEmpty(request.Description) ? video.Description : request.Description;
    video.DescriptionAr = string.IsNullOrEmpty(request.DescriptionAr) ? video.DescriptionAr : request.DescriptionAr;
    video.PlayerId = request.PlayerId == 0 ? video.PlayerId : request.PlayerId;
    video.VideoType = string.IsNullOrEmpty(request.VideoType) ? video.VideoType : request.VideoType;
    video.Time = request.Time == 0 ? video.Time : request.Time;
    video.CategoryId = request.CategoryId == 0 ? video.CategoryId : request.CategoryId;
    video.ModifiedById = Guid.Parse(request.AdminId);
    video.ModifiedOn = DateTime.Now;

  }
}
