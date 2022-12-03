using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhliFans.Core.Feature.Admin.NormalVideo.GetAll.DTO;
public record NormalVideoDto(
  int NormalVideoId, string Month, string VideoURL, string Description, string SeasonName, int MatchId,
  string LeagueName, string? PlayerName, string? CoachName, string CategoryName, DateTime CreatedOn,
  DateTime? ModifiedOn, bool IsDeleted, string CreatedBy, Guid CreatedById, string ModifiedBy, Guid? ModifiedById);




