namespace AhliFans.DTO;
public class RoutesConfig
{
    public const string DynamicModules = "Admin/DynamicModules";
    public const string GetAllDynamicModules = "Admin/GetAllDynamicModules";

    public const string ClientDynamicModules = "client/DynamicModules";
    public const string ClientGetAllDynamicModules = "client/GetAllDynamicModules";

    public const string ClientGetAllOnThisDayDynamicModules = "client/GetOnThisDay";
    public const string ClientGetAllCalanderDayDynamicModules = "client/GetCalander";
    public const string ClientGetAllLegent = "client/GetAllLegent";
    public const string ClientGetSquadList = "client/GetSquadList";
}

public enum Modules
{
    OneThisDay = 1,
    CalendarManagement
}

public enum Sections
{
    LegendBirthday = 1,
    ImportantMatch,
    BigTrophies,
    Events,
    RegularBirthdays
}
