using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhliFans.Core.Feature.Admin.MediaPhoto.GetAll.DTO;
public record PhotoDto(
  int PhotoId, string image, string Month, string? PhotoLink, string Description, bool IsExclusiveContent, string SeasonName, int MatchId, 
  string LeagueName, string? PlayerName, string? CoachName , string CategoryName, DateTime CreatedOn,
  DateTime? ModifiedOn, bool IsDeleted, string CreatedBy, Guid CreatedById, string ModifiedBy, Guid? ModifiedById);





