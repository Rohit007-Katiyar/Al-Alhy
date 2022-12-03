namespace AhliFans.Core.Feature.Fan.Coach.GetInfo.DTO;

public record CoachDto(int Id, string Country, string Nationality, string City, string Title, string FirstName, string LastName,
  DateTime BirthDate,int Age, DateTime DateSigned, string Biography, bool IsCurrent, DateTime CreationTime,bool IsDeleted);
