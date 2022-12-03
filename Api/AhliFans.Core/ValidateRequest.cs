using AhliFans.Core.Feature.Entities;
using AhliFans.DTO;
using AhliFans.SharedKernel.APIServices.Cequens.Model;
using Newtonsoft.Json;
using System.Globalization;
using DynamicModules = AhliFans.Core.Feature.Entities.DynamicModules;

namespace AhliFans.Core;
public static class ValidateRequest
{
    public static dynamic ValidateRequestPayload(DTO.DynamicModules dynamicModules, int? applicationType)
    {
        switch (dynamicModules.ModuleType)
        {
            case (int)Modules.OneThisDay:
                return ValidateOnThisDay(dynamicModules, applicationType);
            case (int)Modules.CalendarManagement:
                return ValidateCalendarManagement(dynamicModules, applicationType);
            default:
                return default;
        }
    }

    public static dynamic ValidateOnThisDay(DTO.DynamicModules dynamicModules, int? applicationType)
    {
        switch (dynamicModules.SectionType)
        {
            case (int)Sections.LegendBirthday:

                if (applicationType == 1)
                {
                    DTO.LegentList legendsBirthdaysDto = new LegentList();
                    var data = JsonConvert.DeserializeObject<LegendBirthdays>(dynamicModules.Section);
                    legendsBirthdaysDto.birth_date = data?.Date?.ToString("dd/M/yyyy");
                    legendsBirthdaysDto.playerName = data.LegendName;
                    legendsBirthdaysDto.description = data.Description;
                    legendsBirthdaysDto.imageThumnail = data.Media;
                    return legendsBirthdaysDto;
                }
                else
                {
                    return JsonConvert.DeserializeObject<LegendBirthdays>(dynamicModules.Section);
                }
            case (int)Sections.ImportantMatch:
                return JsonConvert.DeserializeObject<ImportantMatch>(dynamicModules.Section);
            case (int)Sections.BigTrophies:
                return JsonConvert.DeserializeObject<BigTrophies>(dynamicModules.Section);
            default:
                return default;
        }
    }

    private static dynamic ValidateCalendarManagement(DTO.DynamicModules dynamicModules, int? applicationType)
    {
        switch (dynamicModules.SectionType)
        {
            case (int)Sections.Events:
                if (applicationType == 1)
                {
                    EventDto eventDto = new EventDto();
                    var data = JsonConvert.DeserializeObject<Events>(dynamicModules.Section);
                    eventDto.title = "Events";
                    eventDto.type = "event";
                    eventDto.event_startdate = data.DateFrom.ToString("dd/M/yyyy");
                    eventDto.event_enddate = data.DateTo.ToString("dd/M/yyyy");
                    eventDto.location = data.Location;
                    eventDto.event_time = data.EventTimeFrom + " to " + data.EventTimeTo;
                    eventDto.eventName = data.EventName;
                    eventDto.description = data.Description;
                    eventDto.imageThumnail = data.Media;
                    return eventDto;
                }
                else
                {
                    return JsonConvert.DeserializeObject<Events>(dynamicModules.Section);
                }
            case (int)Sections.RegularBirthdays:
                return JsonConvert.DeserializeObject<RegularBirthDay>(dynamicModules.Section);
            default:
                return default;
        }
    }

    public static dynamic ValidateModule(Modules modules, Sections sections, string? json)
    {
        switch (modules)
        {
            case Modules.OneThisDay:
                return ValidateSectionOnThisDay(sections, json);
            case Modules.CalendarManagement:
                return ValidateSectionCalendarManagement(sections, json);
            default:
                return default;
        }
    }

    public static dynamic ValidateSectionOnThisDay(Sections sections, string? json)
    {
        switch (sections)
        {
            case Sections.LegendBirthday:
                return string.IsNullOrEmpty(json) ? new LegendBirthdays() : JsonConvert.DeserializeObject<LegendBirthdays>(json);
            case Sections.ImportantMatch:
                return string.IsNullOrEmpty(json) ? new ImportantMatch() : JsonConvert.DeserializeObject<ImportantMatch>(json);
            case Sections.BigTrophies:
                return string.IsNullOrEmpty(json) ? new BigTrophies() : JsonConvert.DeserializeObject<BigTrophies>(json);
            default:
                return default;
        }
    }

    public static dynamic ValidateSectionCalendarManagement(Sections sections, string json)
    {
        switch (sections)
        {
            case Sections.Events:
                return string.IsNullOrEmpty(json) ? new Events() : JsonConvert.DeserializeObject<Events>(json);
            case Sections.RegularBirthdays:
                return string.IsNullOrEmpty(json) ? new RegularBirthDay() : JsonConvert.DeserializeObject<RegularBirthDay>(json);
            default:
                return false;
        }
        return false;
    }
}
