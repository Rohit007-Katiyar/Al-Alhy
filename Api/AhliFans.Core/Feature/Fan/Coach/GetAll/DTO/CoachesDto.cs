namespace AhliFans.Core.Feature.Fan.Coach.GetAll.DTO;

public record CoachesDto(int Id,string Nationality, string City, string Title, string FirstName, string LastName, bool IsCurrent,bool IsDeleted);
