namespace AhliFans.Core.Feature.Fan.Preferences.Get.DTO;

public record PreferenceDto(PlayerDto FavPlayer, FavMatchDto FavMatch, LocalTrophyDto FavLocalTrophy, AfricanTrophyDto FavAfricanTrophy, string FavPlayerAllTime, string FavMoment, string FavCoachAllTime);
public record PlayerDto (int PlayerId,string PlayerName);
public record FavMatchDto(int FavMatchId, string FavMatchName);
public record LocalTrophyDto(int LocalTrophyId, string LocalTrophyName);
public record AfricanTrophyDto(int AfricanTrophyId, string AfricanTrophyName);
