namespace AhliFans.Core.Feature.Admin.Category.GetById.DTO;

public record CategoryDetailsDto(int Id, string Name, string NameAr, string Description, string DescriptionAr,
   bool photo,
  bool video,
  bool otd,
  DateTime CreatedOn,
  DateTime? ModifiedOn, bool IsDeleted, string? CreatedBy,
  Guid CreatedById, string? ModifiedBy, Guid? ModifiedById);
