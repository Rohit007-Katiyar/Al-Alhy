
namespace AhliFans.Core.Feature.Admin.MediaPhoto.GetById.DTO;
  public record PhotoDetailsDto(int PhotoId, string image, int SeasonId,string SeasonName, string Month, string? PhotoLink,
  int MatchId, int LeagueId, string LeagueName, string Description, string DescriptionAr, 
  int? PlayerId, string? PlayerName, int? CoachId, string? CoachName, int CategoryId, string CategoryName,
  bool? IsExclusiveContent, DateTime CreatedOn, DateTime? ModifiedOn, bool IsDeleted, string? CreatedBy,
  Guid CreatedById, string? ModifiedBy, Guid? ModifiedById);
