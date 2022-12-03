using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AhliFans.Core.Feature.Fan.Match.GetByMatchId.DTO;
using AhliFans.Core.Feature.Fan.Match.GetByMatchId.Specifications;
using AhliFans.Core.Feature.Fan.Match.GetById.DTO;
using AhliFans.DTO;
using AhliFans.Core.Feature.Fan.SquadList.GetAll.Dto;
using AhliFans.Core.Feature.Fan.SquadList.GetAll.Specifications;

namespace AhliFans.Core.Feature.Fan.Match.GetByMatchId.Events;
public class GetMatchByIdHandlers : IRequestHandler<GetMatchByIdEvents, ActionResult>
{
    private readonly IRepository<Entities.Match> _repository;
    private readonly IRepository<Entities.SquadList> _repository1;

    private readonly IMapper _mapper;

    public GetMatchByIdHandlers(IRepository<Entities.Match> repository, IRepository<Entities.SquadList> repository1, IMapper mapper)
    {
        _repository = repository;
        _repository1 = repository1;
        _mapper = mapper;
    }

    public async Task<ActionResult> Handle(GetMatchByIdEvents request, CancellationToken cancellationToken)
    {
        var match = await _repository.GetBySpecAsync(new GetDataMatchById(request.MatchId), cancellationToken);
        if (match == null) return new NotFoundResult();
        MatchCenterViewModel matchCenterViewModel = new MatchCenterViewModel();
        var dto = _mapper.Map<MatchDetailsDto>(match);

        //Sqaud Data Start
        var squadList = await _repository1.ListAsync(new GetSquadListDataByMatchId(request.MatchId), cancellationToken);
        var isArabic = request.Language == Languages.Ar;
        PlayerListsDtos1 playerListsDtos = new PlayerListsDtos1();

        var da = squadList.GroupBy(x => x.Player?.Position?.GeneralPosition?.Name);
        foreach (var d in da)
        {
            AllSquadListDtolist1 allSquadListDtolist = new AllSquadListDtolist1();
            allSquadListDtolist.playerPosition = d.Key ?? string.Empty;
            foreach (var a in d)
            {
                AllSquadListDto1 allSquadListDto = new AllSquadListDto1();
                allSquadListDto.MatchId = a.MatchId;
                allSquadListDto.PlayerImage = a.Player.Pic ?? string.Empty;
                allSquadListDto.PlayerName = a.Player.Name ?? string.Empty;
                allSquadListDto.playerMatchLineUp = a.Player.Position.Name;
                allSquadListDtolist.list.Add(allSquadListDto);
            }
            matchCenterViewModel.playersList.Add(allSquadListDtolist);
        }
        //Sqaud Data End

        matchCenterViewModel.title = "Matche Center";
        matchCenterViewModel.type = "todayMatches";
        matchCenterViewModel.leagueLogo = "";
        matchCenterViewModel.leagueName = request.Language == Languages.Ar ? match.League.NameAr : match.League.Name;
        matchCenterViewModel.leagueStartDate = match.PlannedDate.ToString("dd/M/yyyy");
        matchCenterViewModel.leagueStartTime = match.PlannedTime.ToString();
        matchCenterViewModel.timeZone = "";
        matchCenterViewModel.team1.teamName = "Al Alhy";
        matchCenterViewModel.team1.teamScore = match.Score;
        matchCenterViewModel.team1.logo = "";
        matchCenterViewModel.team2.teamName = request.Language == Languages.Ar ? match.OpponentTeam.NameAr : match.OpponentTeam.Name;
        matchCenterViewModel.team2.teamScore = match.OpponentScore;
        matchCenterViewModel.team2.logo = match.OpponentTeam.Logo;
        matchCenterViewModel.location = request.Language == Languages.Ar ? match.Stadium.NameAr : match.Stadium.Name;
        return new OkObjectResult(matchCenterViewModel);
    }
}
