using System.IO;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.DTO;
using AhliFans.SharedKernel.APIServices.Cequens.Model;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Newtonsoft.Json;

namespace AhliFans.Core.Feature.Admin.Category.GetAll.Events;
public class GetAllEventHandler : IRequestHandler<DTO.GetAllDynamicModules, ActionResult>
{
    private readonly IRepository<Entities.DynamicModules> _DynamicModulesRepo;

    public GetAllEventHandler(IRepository<Entities.DynamicModules> DynamicModulesRepo)
    {
        _DynamicModulesRepo = DynamicModulesRepo;
    }

    public async Task<ActionResult> Handle(GetAllDynamicModules request, CancellationToken cancellationToken)
    {
        var dynamicModules = await _DynamicModulesRepo.ListAsync();


        var filterRecords = dynamicModules.Where(m => m.ModuleType == request.ModuleType && m.SectionType == request.SectionType &&
           m.IsDeleted == request.IsDelete).OrderByDescending(m => m.UpdatedDate).ToList();

        if (request.ModuleType == 1 && request.Type == 1)
        {
            var filterRecords1 = dynamicModules.Where(m => m.ModuleType == request.ModuleType).ToList();

            var response = new OkObjectResult(OnThisDayList(request, filterRecords1, (Modules)request.ModuleType));
            return new OkObjectResult(response.Value);
        }
        else if (request.ModuleType == 2 && request.Type == 1)
        {
            var filterRecords1 = dynamicModules.ToList();

            var response = new OkObjectResult(CalenderManagementList(request, filterRecords1, (Modules)request.ModuleType));
            return new OkObjectResult(response.Value);
        }
        else
        {
            if (string.IsNullOrEmpty(request.SearchWord))
            {
                var _skip = request.PageSize * (request.PageIndex);
                filterRecords = filterRecords.Skip(_skip).Take(request.PageSize).ToList();

                var response = new OkObjectResult(ConvertIntoList(request, filterRecords, (Modules)request.ModuleType, (Sections)request.SectionType));
                if (request.Type == (int)Areas.Client)
                {
                    return new OkObjectResult(new
                    {
                        Message = "",
                        StatusCode = 200,
                        Data = response
                    });
                }
                return new OkObjectResult(response?.Value ?? default);
            }
            else
            {
                var response = new OkObjectResult(ConvertIntoList(request, filterRecords, (Modules)request.ModuleType, (Sections)request.SectionType));
                if (request.Type == (int)Areas.Client)
                {
                    return new OkObjectResult(new
                    {
                        Message = "",
                        StatusCode = 200,
                        Data = response
                    });
                }
                return new OkObjectResult(response?.Value ?? default);
            }
        }
    }

    private dynamic ConvertIntoList(GetAllDynamicModules request, List<Entities.DynamicModules> filterRecords, Modules modules, Sections sections)
    {
        if (modules == Modules.OneThisDay)
        {
            switch (sections)
            {
                case Sections.LegendBirthday:
                    var _legendBirthdays = new List<LegendBirthdays>();
                    filterRecords.ForEach(m =>
                    {
                        var res = ValidateRequest.ValidateModule(modules, sections, m.Section);
                        res.Id = m.Id;
                        res.IsDeleted = m.IsDeleted;
                        _legendBirthdays.Add(res);
                    });
                    if (!string.IsNullOrEmpty(request.SearchWord))
                    {
                        return _legendBirthdays.Where(m => m.LegendName.ToLower().Contains(request.SearchWord.Trim().ToLower())).Select(m => m).ToList();
                    }
                    return _legendBirthdays;
                case Sections.ImportantMatch:
                    var _ImportantMatch = new List<ImportantMatch>();
                    filterRecords.ForEach(m =>
                    {
                        var res = ValidateRequest.ValidateModule(modules, sections, m.Section);
                        res.Id = m.Id;
                        res.IsDeleted = m.IsDeleted;
                        _ImportantMatch.Add(res);
                    });
                    if (!string.IsNullOrEmpty(request.SearchWord))
                    {
                        return _ImportantMatch.Where(m => m.AlAhly.ToLower().Contains(request.SearchWord.Trim().ToLower())).ToList();
                    }
                    return _ImportantMatch;
                case Sections.BigTrophies:
                    var _BigTrophies = new List<BigTrophies>();
                    filterRecords.ForEach(m =>
                    {
                        var res = ValidateRequest.ValidateModule(modules, sections, m.Section);
                        res.Id = m.Id;
                        res.IsDeleted = m.IsDeleted;
                        _BigTrophies.Add(res);
                    });
                    if (!string.IsNullOrEmpty(request.SearchWord))
                    {
                        return _BigTrophies.Where(m => m.TrophyName.ToLower().Contains(request.SearchWord.Trim().ToLower())).ToList();
                    }
                    return _BigTrophies;
                default:
                    return default;
            }
        }
        if (Modules.CalendarManagement == modules)
        {
            switch (sections)
            {
                case Sections.Events:
                    var _legendBirthdays = new List<DTO.Events>();
                    try
                    {
                        filterRecords.ForEach(m =>
                        {
                            var res = ValidateRequest.ValidateModule(modules, sections, m.Section);
                            res.Id = m.Id;
                            res.IsDeleted = m.IsDeleted;
                            _legendBirthdays.Add(res);
                        });
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                    if (!string.IsNullOrEmpty(request.SearchWord))
                    {
                        return _legendBirthdays.Where(m => m.EventName.ToLower().Contains(request.SearchWord.ToLower())).ToList();
                    }
                    return _legendBirthdays;
                case Sections.RegularBirthdays:
                    var _ImportantMatch = new List<DTO.RegularBirthDay>();
                    filterRecords.ForEach(m =>
                    {
                        var res = ValidateRequest.ValidateModule(modules, sections, m.Section);
                        res.Id = m.Id;
                        res.IsDeleted = m.IsDeleted;
                        _ImportantMatch.Add(res);
                    });
                    if (!string.IsNullOrEmpty(request.SearchWord))
                    {
                        return _ImportantMatch.Where(m => m.PlayerName.ToLower().Contains(request.SearchWord.ToLower())).ToList();
                    }
                    return _ImportantMatch;
                default:
                    return default;
            }
        }
        return default;
    }

    private OnthisDayViewModels OnThisDayList(GetAllDynamicModules request, List<Entities.DynamicModules> filterRecords, Modules modules)
    {
        OnthisDayViewModels onthisDayViewModels = new OnthisDayViewModels();
        OnthisDayViewModel events = new OnthisDayViewModel();
        if (modules == Modules.OneThisDay)
        {
            filterRecords.ForEach(m =>
            {
                var res = ValidateRequest.ValidateSectionOnThisDay((Sections)m.SectionType, m.Section);

                if (m.SectionType == 1)
                {
                    LegendBirthdayDto legendBirthdayDto = new LegendBirthdayDto();
                    if (res.Date != null)
                    {
                        legendBirthdayDto.birth_date = res.Date.ToString("dd/M/yyyy");
                    }
                    else
                    {
                        legendBirthdayDto.birth_date = string.Empty;
                    }
                    legendBirthdayDto.playerName = res.LegendName;
                    legendBirthdayDto.description = res.Description;
                    legendBirthdayDto.imageThumnail = res.Media;
                    events.legendBirthdayViewModel.data.Add(legendBirthdayDto);
                }
                if (m.SectionType == 2)
                {
                    ImportantMatchResultDto importantMatchDto = new ImportantMatchResultDto();
                    importantMatchDto.date = res.DateofMatch;
                    importantMatchDto.enddate = res.DateofMatch;
                    try
                    {
                        if (res.AlAhlyScore != null)
                        {
                            importantMatchDto.team1.teamScore = int.Parse(res.AlAhlyScore);
                        }
                        else
                        {
                            importantMatchDto.team1.teamScore = 0;
                        }

                        importantMatchDto.team1.teamName = res.AlAhly;
                        if (res.AlAhlyScore != null)
                        {
                            importantMatchDto.team2.teamScore = int.Parse(res.AlAhlyScore);
                        }
                        else
                        {
                            importantMatchDto.team2.teamScore = 0;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    importantMatchDto.team2.teamName = res.OtherTeam ?? string.Empty;
                    importantMatchDto.matchName = null;
                    importantMatchDto.teamName2 = res.OtherTeam ?? string.Empty;
                    importantMatchDto.description = res.Description;
                    importantMatchDto.imageThumnail = res.Media;
                    events.importantMatchViewModel.data.Add(importantMatchDto);
                }

                if (m.SectionType == 3)
                {
                    BigTrophiesDto bigTrophiesDto = new BigTrophiesDto();
                    bigTrophiesDto.date = res.DateofTrophy.ToString("dd/M/yyyy");
                    bigTrophiesDto.matchName = res.TrophyType;
                    bigTrophiesDto.description = res.Description;
                    bigTrophiesDto.imageThumnail = res.Media;
                    events.bigTrophyViewModel.data.Add(bigTrophiesDto);
                }
            });
        }
        onthisDayViewModels.events.Add(events);
        return onthisDayViewModels;
    }

    private CalendarViewModels CalenderManagementList(GetAllDynamicModules request, List<Entities.DynamicModules> filterRecords, Modules modules)
    {
        CalendarViewModels calendarViewModels = new CalendarViewModels();
        CalendarViewModel calendarViewModel = new CalendarViewModel();
        calendarViewModel.birthday.title = "Birthdays";
        calendarViewModel.birthday.type = "birthday";
        calendarViewModel.birthday_stuff.title = "Al Ahly Stuff";
        calendarViewModel.birthday_stuff.type = "birthday_stuff";

        if (modules == Modules.CalendarManagement)
        {
            filterRecords.ForEach(m =>
            {
                if (m.SectionType == 1)
                {
                    var res = ValidateRequest.ValidateSectionOnThisDay((Sections)m.SectionType, m.Section);
                    LegentList legendBirthdayDto = new LegentList();
                    legendBirthdayDto.birth_date = res.Date.ToString("dd/M/yyyy") ?? string.Empty;
                    legendBirthdayDto.playerName = res.LegendName;
                    legendBirthdayDto.description = res.Description;
                    legendBirthdayDto.imageThumnail = res.Media;
                    calendarViewModel.birthday.data.Add(legendBirthdayDto);
                }
                if (m.SectionType == 2)
                {
                    var res = ValidateRequest.ValidateSectionOnThisDay((Sections)m.SectionType, m.Section);
                    LegentList legendBirthdayDto = new LegentList();
                    legendBirthdayDto.birth_date = res.Date.ToString("dd/M/yyyy") ?? string.Empty;
                    legendBirthdayDto.playerName = res.LegendName;
                    legendBirthdayDto.description = res.Description;
                    legendBirthdayDto.imageThumnail = res.Media;
                    calendarViewModel.birthday.data.Add(legendBirthdayDto);
                }



                if (m.SectionType == 5)
                {
                    var res = ValidateRequest.ValidateSectionCalendarManagement((Sections)m.SectionType, m.Section);
                    LegentList legendBirthdayDto = new LegentList();
                    legendBirthdayDto.birth_date = res.BirthDate.ToString("dd/M/yyyy") ?? string.Empty;
                    legendBirthdayDto.playerName = res.PlayerName;
                    legendBirthdayDto.description = null;
                    legendBirthdayDto.imageThumnail = res.Media;
                    calendarViewModel.birthday_stuff.data.Add(legendBirthdayDto);
                }
                if (m.SectionType == 4)
                {
                    var res = ValidateRequest.ValidateSectionCalendarManagement((Sections)m.SectionType, m.Section);
                    EventDetailCalendarViewModel eventCalendarViewModel = new EventDetailCalendarViewModel();
                    eventCalendarViewModel.event_startdate = res.DateFrom.ToString("dd/M/yyyy") ?? string.Empty;
                    eventCalendarViewModel.event_enddate = res.DateTo.ToString("dd/M/yyyy") ?? string.Empty;
                    eventCalendarViewModel.location = res.Location;
                    eventCalendarViewModel.event_time = res.EventTimeFrom + " to " + res.EventTimeTo;
                    eventCalendarViewModel.eventName = res.EventName;
                    eventCalendarViewModel.description = res.Description;
                    eventCalendarViewModel.imageThumnail = res.Media;
                    calendarViewModel.eventData.data.Add(eventCalendarViewModel);
                }
            });
        }
        calendarViewModels.events.Add(calendarViewModel);
        return calendarViewModels;
    }
}
