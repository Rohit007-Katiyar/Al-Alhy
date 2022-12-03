using AhliFans.Core.Feature.Fan.Category.GetAll.DTO;
using AhliFans.Core.Feature.Fan.Category.GetAll.Specifications;
using AhliFans.Core.Feature.Fan.Category.GetById.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Responses;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Category.GetById.Events;
internal class GetByCategoryIdHandler : IRequestHandler<GetByCategoryIdEvent, ActionResult>
{
  private readonly IRepository<Entities.Category> _categoryRepository;
  private readonly IRepository<Entities.MediaPhoto> _photoRepository;
  private readonly IRepository<Entities.NormalVideo> _normalVideoRepository;
  private readonly IRepository<Entities.MomentVideo> _momentVideoRepository;
  private readonly IRepository<Entities.Team> _teamRepository;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public GetByCategoryIdHandler(IRepository<Entities.Category> categoryRepository,
    IRepository<Entities.MediaPhoto> photoRepository,
     IRepository<Entities.NormalVideo> normalVideoRepository,
     IRepository<Entities.MomentVideo> momentVideoRepository,
     IRepository<Entities.Team> teamRepository,
     IHttpContextAccessor httpContextAccessor
    )
  {
    _categoryRepository = categoryRepository;
    _httpContextAccessor = httpContextAccessor;
    _photoRepository = photoRepository;
    _normalVideoRepository = normalVideoRepository;
    _momentVideoRepository = momentVideoRepository;
    _teamRepository = teamRepository;
  }
  public async Task<ActionResult> Handle(GetByCategoryIdEvent request, CancellationToken cancellationToken)
  {
    List<CategoryFanDto> dto = new List<CategoryFanDto>();
    List<DataDto> data = new List<DataDto>();
    List<CategoryIDNameListDto> res = new List<CategoryIDNameListDto>();
    List<DataDto> subCatgories = new List<DataDto>();
    try
    {
      var categories = await _categoryRepository.ListAsync(new GetByCategoryId(request.CategoryId), cancellationToken);
      if (categories.Count != 0)
      {
        var photoList = await _photoRepository.ListAsync(new GetAllPhoto(), cancellationToken);
        var normalVideoList = await _normalVideoRepository.ListAsync(new GetAllNormalVideo(), cancellationToken);
        var momentVideoList = await _momentVideoRepository.ListAsync(new GetAllMomentVideo(), cancellationToken);
        var teamList = await _teamRepository.ListAsync(new GetAllTeam(), cancellationToken);

        foreach (var item in categories)
        {
          string CategoryName = item.Name;
          if (request.Lang == Languages.Ar)
          {
            CategoryName = item.NameAr;
          }
          int skip = request.pageSize * request.pageIndex;
          int take = request.pageSize;
          var photoByCatId = photoList.Where(x => x.CategoryId == item.Id).OrderByDescending(m => m.CreatedOn).ToList();
          var normalVideoByCatId = normalVideoList.Where(x => x.CategoryId == item.Id).OrderByDescending(m => m.CreatedOn).ToList();
          var momentVideoByCatId = momentVideoList.Where(x => x.CategoryId == item.Id).OrderByDescending(m => m.CreatedOn).ToList();

          if (photoByCatId.Count > 0)
          {
            foreach (var photo in photoByCatId)
            {
              string LeagueName = photo.League.Name;
              if (request.Lang == Languages.Ar)
              {
                LeagueName = photo.League.NameAr;
              }
              //get match name 
              var team = teamList.Where(x => x.Id == photo.Match.OpponentTeamId).ToList();
              string MatchName = "AI Ahly vs " + team[0].Name;
              if (request.Lang == Languages.Ar)
              {
                MatchName = team[0].NameAr + " الاهلي ضد";
              }
              subCatgories.Add(new DataDto(LeagueName,
                MatchName, team[0]?.Logo, photo.Photo, false, photo.IsExclusiveContent, photo.Month, string.Empty,
                "MediaPhotos", photo.CreatedOn));
            }
          }

          //bind normal  video list
          if (normalVideoByCatId.Count > 0)
          {
            foreach (var video in normalVideoByCatId)
            {
              string LeagueName = video.League.Name;
              if (request.Lang == Languages.Ar)
              {
                LeagueName = video.League.NameAr;
              }
              //get match name 
              var team = teamList.Where(x => x.Id == video.Match.OpponentTeamId).ToList();
              string MatchName = "AI Ahly vs " + team[0].Name;
              if (request.Lang == Languages.Ar)
              {
                MatchName = team[0].NameAr + " الاهلي ضد";
              }
              var fileName = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/NormalVideo/NormalVideo_{video.Id}.png";
              subCatgories.Add(new DataDto(
                LeagueName, MatchName, team[0]?.Logo, video.VideoURL, true, null, video.Month, fileName, "NormalVideo",
                video.CreatedOn
                ));
            };
          }

          //bind  moment video list
          if (momentVideoByCatId.Count > 0)
          {
            foreach (var video in momentVideoByCatId)
            {
              string LeagueName = video.League.Name;
              if (request.Lang == Languages.Ar)
              {
                LeagueName = video.League.NameAr;
              }
              //get match name 
              var team = teamList.Where(x => x.Id == video.Match.OpponentTeamId).ToList();
              string MatchName = "AI Ahly vs " + team[0].Name;
              if (request.Lang == Languages.Ar)
              {
                MatchName = team[0].NameAr + " الاهلي ضد";
              }
              var fileName = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/MomentVideo/MomentVideo_{video.Id}.png";
              subCatgories.Add(new DataDto(
                LeagueName, MatchName, team[0]?.Logo, video.VideoURL, true, null, video.Month.ToString(), fileName,
                "MomentVideo",
                video.CreatedOn));
            };
          }
          
          var _subCategories = subCatgories.OrderByDescending(d => d.createdDate).Skip(skip).Take(take).ToList();
          res.Add(new CategoryIDNameListDto(item.Id, CategoryName, _subCategories));
        };
      }
    }
    catch
    {
      //res.Add(new CategoryIDNameListDto(2, "Error", data));
    }
    return new OkObjectResult(new APIResponse<CategoryIDNameListDto> { res = res });
  }
}
