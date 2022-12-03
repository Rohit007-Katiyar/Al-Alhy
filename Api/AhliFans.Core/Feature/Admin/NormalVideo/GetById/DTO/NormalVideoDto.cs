using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhliFans.Core.Feature.Admin.NormalVideo.GetById.DTO;
public record NormalVideoDto(int NormalVideoId, int SeasonId, string SeasonName, string Month, string VideoURL,
  int MatchId, int LeagueId, string LeagueName, string Description, string DescriptionAr,
  int? PlayerId, string? PlayerName, int? CoachId, string? CoachName, int CategoryId, string CategoryName,
  DateTime CreatedOn, DateTime? ModifiedOn, bool IsDeleted, string? CreatedBy,
  Guid CreatedById, string? ModifiedBy, Guid? ModifiedById);
