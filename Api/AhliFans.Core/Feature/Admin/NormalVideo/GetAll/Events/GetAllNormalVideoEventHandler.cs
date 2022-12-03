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
using AhliFans.Core.Feature.Admin.NormalVideo.GetAll.Specification;
using AhliFans.Core.Feature.Admin.NormalVideo.GetAll.DTO;

namespace AhliFans.Core.Feature.Admin.NormalVideo.GetAll.Events;
public class GetAllNormalVideoEventHandler : IRequestHandler<GetAllNormalVideoEvent, ActionResult>
{
  private readonly IRepository<Entities.NormalVideo> _normalVideoRepository;
  public GetAllNormalVideoEventHandler(IRepository<Entities.NormalVideo> normalVideoRepository)
  {
    _normalVideoRepository = normalVideoRepository;
  }
  public async Task<ActionResult> Handle(GetAllNormalVideoEvent request, CancellationToken cancellationToken)
  {
    var photo = await _normalVideoRepository.ListAsync(new GetAllNormalVideo(request.PageIndex, request.PageSize, request.SearchWord!, request.IsDeleted), cancellationToken);
    if (photo.Count == 0) return new OkObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    var photos = photo.Select(c => new NormalVideoDto(
                      c.Id,
                      c.Month,
                      c.VideoURL,
                      request.Lang == Languages.En ? c.Description : c.DescriptionAr,
                      c.Season.StartDate.Year + "-" + c.Season?.EndDate?.Year,
                      c.MatchId ?? 0,
                      request.Lang == Languages.En ? c.League.Name : c.League.NameAr,
                      request.Lang == Languages.En ? c.Player.Name : c.Player.NameAr,
                      request.Lang == Languages.En ? c.Coach.FirstName + ' ' + c.Coach.LastName : c.Coach.FirstNameAr + ' ' + c.Coach.LastNameAr,
                      request.Lang == Languages.En ? c.Category?.Name ?? "" : c.Category?.NameAr ?? "",
                      c.CreatedOn,
                      c.ModifiedOn,
                      c.IsDeleted,
                      c.CreatedBy?.FullName!,
                      c.CreatedById,
                      c.ModifiedBy?.FullName!,
                      c.ModifiedById));

    return new OkObjectResult(photos);
  }
}
