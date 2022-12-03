namespace AhliFans.Core.Feature.Admin.Category;

public record CategoryDto(int CategoryId, string Name, string Description, bool photo, bool video, bool otd, DateTime CreatedOn,
  DateTime? ModifiedOn, bool IsDeleted, string CreatedBy, Guid CreatedById, string ModifiedBy,Guid? ModifiedById);
