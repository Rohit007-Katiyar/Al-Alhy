namespace AhliFans.Core.Feature.Admin.Coach.GetById.DTO;

public record CoachDto(int Id, string Nationality, string City, string Title, string FirstName, string FirstNameAr, string LastName, string LastNameAr,
  DateTime BirthDate, DateTime DateSigned, string Biography, string BiographyAr, bool IsCurrent, DateTime CreationTime, bool IsDeleted, string TeamCategoryName, int? TeamCategoryId , int? countryId
  ,string TitleName , string CityName
  );
