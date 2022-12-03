using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Security.Entities;
using AhliFans.Infrastructure.Seeds.MatchStatistics;
using AhliFans.Infrastructure.Seeds.Preferences;
using AhliFans.SharedKernel;
using Ardalis.EFCore.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Fan = AhliFans.Core.Feature.Security.Entities.Fan;

namespace AhliFans.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<User,
                                              Role,
                                              Guid,
                                              UserClaim,
                                              UserRole,
                                              UserLogin,
                                              RoleClaim,
                                              UserToken>

{
  private readonly IMediator? _mediator;
  public virtual DbSet<Admin> Admins { get; set; } = null!;
  public virtual DbSet<NotificationSetting> NotificationSettings { get; set; } = null!;
  public virtual DbSet<MomentVote> MomentVotes { get; set; } = null!;
  public virtual DbSet<Moment> Moments { get; set; } = null!;
  public virtual DbSet<PlayerVote> PlayerVotes { get; set; } = null!;
  public virtual DbSet<Substitution> Substitutions { get; set; } = null!;
  public virtual DbSet<MatchPlayer> MatchPlayers { get; set; } = null!;
  public virtual DbSet<Notification> Notifications { get; set; } = null!;
  public virtual DbSet<FanNotification> FanNotifications { get; set; } = null!;
  public virtual DbSet<City> Cities { get; set; } = null!;
  public virtual DbSet<League> Leagues { get; set; } = null!;
  public virtual DbSet<LeagueDates> LeagueDates { get; set; } = null!;
  public virtual DbSet<Country> Countries { get; set; } = null!;
  public virtual DbSet<BroadcastChannel> BroadcastChannels { get; set; } = null!;
  public virtual DbSet<Coach> Coaches { get; set; } = null!;
  public virtual DbSet<Event> Events { get; set; } = null!;
  public virtual DbSet<Fan> Fans { get; set; } = null!;
  public virtual DbSet<FanPreference> FanPreferences { get; set; } = null!;
  public virtual DbSet<Honor> Honors { get; set; } = null!;
  public virtual DbSet<LegendBirthDate> LegendBirthDates { get; set; } = null!;
  public virtual DbSet<Match> Matches { get; set; } = null!;
  public virtual DbSet<MatchBroadcastChannel> MatchBroadcastChannels { get; set; } = null!;
  public virtual DbSet<MatchEvent> MatchEvents { get; set; } = null!;
  public virtual DbSet<MatchEventType> MatchEventTypes { get; set; } = null!;
  public virtual DbSet<MatchLineUp> MatchLineUps { get; set; } = null!;
  public virtual DbSet<MatchStatistic> MatchStatistics { get; set; } = null!;
  public virtual DbSet<MatchStatisticsType> MatchStatisticsTypes { get; set; } = null!;
  public virtual DbSet<MatchStatisticsTypeCoefficient> MatchStatisticsTypeCoefficients { get; set; } = null!;
  public virtual DbSet<MatchTag> MatchTags { get; set; } = null!;
  public virtual DbSet<MediaTag> MediaTags { get; set; } = null!;
  public virtual DbSet<PersonalAchievement> PersonalAchievements { get; set; } = null!;
  public virtual DbSet<Photo> Photos { get; set; } = null!;
  public virtual DbSet<Player> Players { get; set; } = null!;
  public virtual DbSet<PlayerTeam> PlayerTeams { get; set; } = null!;
  public virtual DbSet<Position> Positions { get; set; } = null!;
  public virtual DbSet<Referee> Referees { get; set; } = null!;
  public virtual DbSet<Season> Seasons { get; set; } = null!;
  public virtual DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; } = null!;
  public virtual DbSet<SquadList> SquadLists { get; set; } = null!;
  public virtual DbSet<Stadium> Stadia { get; set; } = null!;
  public virtual DbSet<Tag> Tags { get; set; } = null!;
  public virtual DbSet<Team> Teams { get; set; } = null!;
  public virtual DbSet<TeamType> TeamTypes { get; set; } = null!;
  public virtual DbSet<Title> Titles { get; set; } = null!;
  public virtual DbSet<Trophy> Trophies { get; set; } = null!;
  public virtual DbSet<Category> Category { get; set; } = null!;
  public virtual DbSet<MediaPhoto> MediaPhoto { get; set; } = null!;
  public virtual DbSet<NormalVideo> NormalVideo { get; set; } = null!;
  public virtual DbSet<MomentVideo> MomentVideo { get; set; } = null!;
  public virtual DbSet<TrophyHistory> TrophyHistories { get; set; } = null!;
  public virtual DbSet<TrophyType> TrophyTypes { get; set; } = null!;
  public virtual DbSet<Video> Videos { get; set; } = null!;
  public virtual DbSet<Jersey> Jerseys { get; set; } = null!;
  public virtual DbSet<MatchGoal> MatchesGoals { get; set; } = null!;

  public virtual DbSet<MatchCard> MatchesCards { get; set; } = null!;

  public virtual DbSet<MembershipCard> MembershipCards { get; set; } = null!;

  public virtual DbSet<UserMembership> UserMemberships { get; set; } = null!;

  public virtual DbSet<DynamicModules> DyanmicModules { get; set; } = null!;

  public AppDbContext(DbContextOptions<AppDbContext> options, IMediator? mediator)
        : base(options)
  {
    _mediator = mediator;
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<User>(entity => { entity.ToTable("User"); });
    modelBuilder.Entity<Fan>(entity => { entity.ToTable("Fan"); });
    modelBuilder.Entity<Admin>(entity => { entity.ToTable("Admin"); });
    modelBuilder.Entity<Role>(entity => { entity.ToTable("Role"); });
    modelBuilder.Entity<UserRole>(entity => { entity.ToTable("UserRole"); });
    modelBuilder.Entity<RoleClaim>(entity => { entity.ToTable("RoleClaim"); });
    modelBuilder.Entity<UserClaim>(entity => { entity.ToTable("UserClaim"); });
    modelBuilder.Entity<UserLogin>(entity => { entity.ToTable("UserLogin"); });
    modelBuilder.Entity<UserToken>(entity => { entity.ToTable("UserToken"); });

    modelBuilder.Entity<DynamicModules>(entity =>
    {
      entity.ToTable("DynamicModules");
    });

    modelBuilder.Entity<BroadcastChannel>(entity =>
    {
      entity.ToTable("BroadcastChannel");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.Property(e => e.Name)
          .HasMaxLength(200)
          .IsUnicode(false);

      entity.Property(e => e.NameAr).HasMaxLength(400);
    });

    modelBuilder.Entity<Coach>(entity =>
    {
      entity.ToTable("Coach");

      entity.Property(e => e.Biography)
          .HasMaxLength(2000)
          .IsUnicode(false);

      entity.Property(e => e.BiographyAr).HasMaxLength(4000);

      entity.Property(e => e.BirthDate).HasColumnType("datetime");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.Property(e => e.DateSigned).HasColumnType("datetime");

      entity.Property(e => e.FirstName)
          .HasMaxLength(200)
          .IsUnicode(false);

      entity.Property(e => e.FirstNameAr).HasMaxLength(400);

      entity.Property(e => e.LastName)
          .HasMaxLength(200)
          .IsUnicode(false);

      entity.Property(e => e.LastNameAr).HasMaxLength(400);

      entity.Property(e => e.Pic)
          .HasMaxLength(50)
          .IsUnicode(false);

      entity.HasOne(d => d.Title)
          .WithMany(p => p.Coaches)
          .HasForeignKey(d => d.TitleId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Coach_Title");
    });

    modelBuilder.Entity<Event>(entity =>
    {
      entity.ToTable("Event");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.Property(e => e.DateFrom).HasColumnType("date");

      entity.Property(e => e.DateTo).HasColumnType("date");

      entity.Property(e => e.Description)
          .HasMaxLength(2000)
          .IsUnicode(false);

      entity.Property(e => e.DescriptionAr).HasMaxLength(4000);

      entity.Property(e => e.Name)
          .HasMaxLength(400)
          .IsUnicode(false);

      entity.Property(e => e.NameAr).HasMaxLength(800);
    });

    modelBuilder.Entity<Fan>(entity =>
    {
      entity.ToTable("Fan");

      entity.Property(e => e.BirthDate).HasColumnType("datetime");

      entity.Property(e => e.FullName).HasMaxLength(200);

      entity.Property(e => e.Gender)
          .HasMaxLength(10)
          .IsUnicode(false);

      entity.Property(e => e.ProfilePic)
          .HasMaxLength(50)
          .IsUnicode(false);
    });

    modelBuilder.Entity<FanPreference>(entity =>
    {
      entity.ToTable("FanPreference");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.HasOne(d => d.Fan)
          .WithMany(p => p.FanPreferences)
          .HasForeignKey(d => d.FanId)
          .OnDelete(DeleteBehavior.Cascade)
          .HasConstraintName("FK_FanPreference_Fan");

      entity.HasOne(d => d.Player)
          .WithMany(p => p.FanPreferences)
          .HasForeignKey(d => d.PlayerId)
          .HasConstraintName("FK_FanPreference_Player");
    });

    modelBuilder.Entity<Honor>(entity =>
    {
      entity.ToTable("Honor");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.HasOne(d => d.Coach)
          .WithMany(p => p.Honors)
          .HasForeignKey(d => d.CoachId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Honor_Coach");

      entity.HasOne(d => d.Player)
          .WithMany(p => p.Honors)
          .HasForeignKey(d => d.PlayerId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Honor_Player");

    });

    modelBuilder.Entity<LegendBirthDate>(entity =>
    {
      entity.ToTable("LegendBirthDate");

      entity.Property(e => e.BirthDate).HasColumnType("datetime");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.Property(e => e.Description)
          .HasMaxLength(400)
          .IsUnicode(false);

      entity.Property(e => e.DescriptionAr).HasMaxLength(800);

      entity.Property(e => e.Name)
          .HasMaxLength(200)
          .IsUnicode(false);

      entity.Property(e => e.NameAr).HasMaxLength(400);
    });

    modelBuilder.Entity<Match>(entity =>
    {
      entity.ToTable("Match");

      entity.Property(e => e.Date).HasColumnType("datetime");


      entity.HasOne(d => d.OpponentTeam)
          .WithMany(p => p.Matches)
          .HasForeignKey(d => d.OpponentTeamId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Match_Team");

      entity.HasOne(d => d.Referee)
          .WithMany(p => p.Matches)
          .HasForeignKey(d => d.RefereeId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Match_Refere");

      entity.HasOne(d => d.Season)
          .WithMany(p => p.Matches)
          .HasForeignKey(d => d.SeasonId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Match_Season");

      entity.HasOne(d => d.Stadium)
          .WithMany(p => p.Matches)
          .HasForeignKey(d => d.StadiumId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Match_Stadium");
    });

    modelBuilder.Entity<MatchBroadcastChannel>(entity =>
    {
      entity.HasOne(d => d.Channel)
          .WithMany(p => p.MatchBroadcastChannels)
          .HasForeignKey(d => d.ChannelId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_MatchBroadcastChannels_BroadcastChannel");

    });

    modelBuilder.Entity<MatchEvent>(entity =>
    {
      entity.ToTable("MatchEvent");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.HasOne(d => d.MatchEventType)
          .WithMany(p => p.MatchEvents)
          .HasForeignKey(d => d.MatchEventTypeId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_MatchEvent_MatchEventType");

      entity.HasOne(d => d.Match)
          .WithMany(p => p.MatchEvents)
          .HasForeignKey(d => d.MatchId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_MatchEvent_Match");
    });

    modelBuilder.Entity<MatchEventType>(entity =>
    {
      entity.ToTable("MatchEventType");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.Property(e => e.Name)
          .HasMaxLength(50)
          .IsUnicode(false);

      entity.Property(e => e.NameAr).HasMaxLength(100);
    });
    modelBuilder.Entity<MatchPlayer>(entity =>
    {
      entity.Property(e => e.IsAvailable);
    });

    modelBuilder.Entity<MatchLineUp>(entity =>
    {
      entity.ToTable("MatchLineUp");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.Property(e => e.X).HasColumnType("decimal(18, 2)");

      entity.Property(e => e.Y).HasColumnType("decimal(18, 2)");

      entity.HasOne(d => d.Match)
          .WithMany(p => p.MatchLineUps)
          .HasForeignKey(d => d.MatchId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_MatchLineUp_Match");

      entity.HasOne(d => d.Player)
          .WithMany(p => p.MatchLineUps)
          .HasForeignKey(d => d.PlayerId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_MatchLineUp_Player");

    });

    modelBuilder.Entity<MatchTag>(entity =>
    {
      entity.ToTable("MatchTag");

      entity.HasOne(d => d.Match)
          .WithMany(p => p.MatchTags)
          .HasForeignKey(d => d.MatchId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_MatchTag_Match");

      entity.HasOne(d => d.Tag)
          .WithMany(p => p.MatchTags)
          .HasForeignKey(d => d.TagId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_MatchTag_Tags");
    });

    modelBuilder.Entity<MediaTag>(entity =>
    {
      entity.ToTable("MediaTag");

      entity.Property(e => e.Id).ValueGeneratedNever();

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.HasOne(d => d.Coach)
          .WithMany(p => p.MediaTags)
          .HasForeignKey(d => d.CoachId)
          .HasConstraintName("FK_MediaTag_Coach");

      entity.HasOne(d => d.Legend)
          .WithMany(p => p.MediaTags)
          .HasForeignKey(d => d.LegendId)
          .HasConstraintName("FK_MediaTag_LegendBirthDate");

      entity.HasOne(d => d.MatchEvent)
          .WithMany(p => p.MediaTags)
          .HasForeignKey(d => d.MatchEventId)
          .HasConstraintName("FK_MediaTag_MatchEvent");

      entity.HasOne(d => d.Photo)
          .WithMany(p => p.MediaTags)
          .HasForeignKey(d => d.PhotoId)
          .HasConstraintName("FK_PlayerTag_Photo");

      entity.HasOne(d => d.Player)
          .WithMany(p => p.MediaTags)
          .HasForeignKey(d => d.PlayerId)
          .HasConstraintName("FK_PlayerTag_Player");

      entity.HasOne(d => d.Video)
          .WithMany(p => p.MediaTags)
          .HasForeignKey(d => d.VideoId)
          .HasConstraintName("FK_PlayerTag_Video");
    });

    modelBuilder.Entity<PersonalAchievement>(entity =>
    {
      entity.ToTable("PersonalAchievement");

      entity.Property(e => e.Name)
          .HasMaxLength(300)
          .IsUnicode(false);

      entity.Property(e => e.NameAr).HasMaxLength(600);
    });

    modelBuilder.Entity<Photo>(entity =>
    {
      entity.ToTable("Photo");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.Property(e => e.FileName).HasMaxLength(200);
    });

    modelBuilder.Entity<Player>(entity =>
    {
      entity.ToTable("Player");

      entity.Property(e => e.Biography)
          .HasMaxLength(2000)
          .IsUnicode(false);

      entity.Property(e => e.BiographyAr).HasMaxLength(4000);

      entity.Property(e => e.BirthDate).HasColumnType("datetime");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.Property(e => e.Name)
          .HasMaxLength(200)
          .IsUnicode(false);

      entity.Property(e => e.NameAr).HasMaxLength(300);

      entity.Property(e => e.Pic)
          .HasMaxLength(50)
          .IsUnicode(false);

      entity.HasOne(d => d.Position)
          .WithMany(p => p.Players)
          .HasForeignKey(d => d.PositionId)
          .HasConstraintName("FK_Player_Position");
    });

    modelBuilder.Entity<PlayerTeam>(entity =>
    {
      entity.ToTable("PlayerTeam");

      entity.Property(e => e.SignedDate).HasColumnType("datetime");

      entity.HasOne(d => d.Player)
          .WithMany(p => p.PlayerTeams)
          .HasForeignKey(d => d.PlayerId)
          .HasConstraintName("FK_PlayerTeam_Player");
    });

    modelBuilder.Entity<Position>(entity =>
    {
      entity.ToTable("Position");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.Property(e => e.Name)
          .HasMaxLength(200)
          .IsUnicode(false);

      entity.Property(e => e.NameAr).HasMaxLength(400);

      entity.Property(e => e.Symbol)
          .HasMaxLength(2)
          .IsUnicode(false);
    });

    modelBuilder.Entity<Referee>(entity =>
    {
      entity.ToTable("Referee");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.Property(e => e.Name)
          .HasMaxLength(200)
          .IsUnicode(false);

      entity.Property(e => e.NameAr).HasMaxLength(400);
    });


    modelBuilder.Entity<Season>(entity =>
    {
      entity.ToTable("Season");

      entity.Property(e => e.CreationDate).HasColumnType("datetime");

      entity.Property(e => e.EndDate).HasColumnType("datetime");

      entity.Property(e => e.Name)
          .HasMaxLength(100)
          .IsUnicode(false);

      entity.Property(e => e.NameAr).HasMaxLength(200);

      entity.Property(e => e.StartDate).HasColumnType("datetime");
    });

    modelBuilder.Entity<SocialMediaAccount>(entity =>
    {
      entity.ToTable("SocialMediaAccount");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.Property(e => e.SocialMediaAccount1)
          .HasMaxLength(200)
          .HasColumnName("SocialMediaAccount");

      entity.HasOne(d => d.Coach)
          .WithMany(p => p.SocialMediaAccounts)
          .HasForeignKey(d => d.CoachId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_SocialMediaAccount_Coach");

      entity.HasOne(d => d.Player)
          .WithMany(p => p.SocialMediaAccounts)
          .HasForeignKey(d => d.PlayerId)
          .HasConstraintName("FK_PlayerSocialMediaAccount_Player");
    });

    modelBuilder.Entity<SquadList>(entity =>
    {
      entity.ToTable("SquadList");

      entity.HasOne(d => d.Match)
          .WithMany(p => p.SquadLists)
          .HasForeignKey(d => d.MatchId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_SquadList_Match");

      entity.HasOne(d => d.Player)
          .WithMany(p => p.SquadLists)
          .HasForeignKey(d => d.PlayerId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_SquadList_Player");
    });

    modelBuilder.Entity<Stadium>(entity =>
    {
      entity.ToTable("Stadium");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.Property(e => e.Name)
          .HasMaxLength(200)
          .IsUnicode(false);

      entity.Property(e => e.NameAr).HasMaxLength(400);

    });

    modelBuilder.Entity<Tag>(entity =>
    {
      entity.Property(e => e.Name)
          .HasMaxLength(200)
          .IsUnicode(false);

      entity.Property(e => e.NameAr).HasMaxLength(400);
    });

    modelBuilder.Entity<Team>(entity =>
    {
      entity.ToTable("Team");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.Property(e => e.Logo)
          .HasMaxLength(50)
          .IsUnicode(false);

      entity.Property(e => e.Name)
          .HasMaxLength(200)
          .IsUnicode(false);

      entity.Property(e => e.NameAr).HasMaxLength(400);

      entity.HasOne(d => d.Type)
          .WithMany(p => p.Teams)
          .HasForeignKey(d => d.TypeId)
          .HasConstraintName("FK_Team_TeamType");
    });

    modelBuilder.Entity<TeamType>(entity =>
    {
      entity.ToTable("TeamType");

      entity.Property(e => e.Name)
          .HasMaxLength(200)
          .IsUnicode(false);

      entity.Property(e => e.NameAr).HasMaxLength(400);
    });

    modelBuilder.Entity<Title>(entity =>
    {
      entity.ToTable("Title");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.Property(e => e.Text)
          .HasMaxLength(200)
          .IsUnicode(false);

      entity.Property(e => e.TextAr).HasMaxLength(400);
    });

    modelBuilder.Entity<Trophy>(entity =>
    {
      entity.ToTable("Trophy");

      entity.Property(e => e.CreatedOn).HasColumnType("datetime");

      entity.Property(e => e.Name)
          .HasMaxLength(200)
          .IsUnicode(false);

      entity.Property(e => e.NameAr).HasMaxLength(400);

      entity.HasOne(d => d.TrophyType)
          .WithMany(p => p.Trophies)
          .HasForeignKey(d => d.TrophyTypeId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Trophy_TrophyType");
    });

    modelBuilder.Entity<TrophyHistory>(entity =>
    {
      entity.ToTable("TrophyHistory");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.HasOne(d => d.Trophy)
          .WithMany(p => p.TrophyHistories)
          .HasForeignKey(d => d.TrophyId)
          .HasConstraintName("FK_TrophyHistory_Trophy");
    });

    modelBuilder.Entity<TrophyType>(entity =>
    {
      entity.ToTable("TrophyType");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.Property(e => e.Name)
          .HasMaxLength(200)
          .IsUnicode(false);

      entity.Property(e => e.NameAr).HasMaxLength(400);
    });

    modelBuilder.Entity<Video>(entity =>
    {
      entity.ToTable("Video");

      entity.Property(e => e.Date).HasColumnType("datetime");

      entity.Property(e => e.FileName).HasMaxLength(200);
    });

    modelBuilder.Entity<MatchStatistic>(entity =>
  {
    entity.HasKey(e => e.Id);
    entity.HasOne(d => d.Match)
        .WithMany(p => p.Statistics)
        .HasForeignKey(d => d.MatchId)
        .HasConstraintName("FK_MatchStatistics_Match");

    entity.HasOne(d => d.StatisticsCoefficient)
        .WithMany(p => p.MatchStatistics)
        .HasForeignKey(d => d.StatisticsCoefficientId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_MatchStatistics_MatchStatisticsTypeCoefficient");

    entity.HasOne(d => d.StatisticsType)
        .WithMany(p => p.MatchStatistics)
        .HasForeignKey(d => d.StatisticsTypeId)
        .HasConstraintName("FK_MatchStatistics_MatchStatisticsType");
  });

    modelBuilder.Entity<MatchStatisticsType>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.ToTable("MatchStatisticsType");

      entity.Property(e => e.Name)
          .HasMaxLength(200)
          .IsUnicode(false);

      entity.Property(e => e.NameAr).HasMaxLength(200);

      entity.HasIndex(t => t.Name).IsUnique();

      entity.HasIndex(t => t.NameAr).IsUnique();
    });

    modelBuilder.Entity<MatchStatisticsTypeCoefficient>(entity =>
    {
      entity.HasKey(e => e.Id);
      entity.ToTable("MatchStatisticsTypeCoefficient");

      entity.Property(e => e.Name)
          .HasMaxLength(200)
          .IsUnicode(false);

      entity.Property(e => e.NameAr).HasMaxLength(200);

      entity.HasOne(d => d.MatchStatisticsType)
          .WithMany(p => p.MatchStatisticsTypeCoefficients)
          .HasForeignKey(d => d.MatchStatisticsTypeId)
          .HasConstraintName("FK_MatchStatisticsTypeCoefficient_MatchStatisticsType");

      entity.HasIndex(c => c.Name).IsUnique();
      entity.HasIndex(c => c.NameAr).IsUnique();
    });

    modelBuilder.Entity<UserMembership>()
      .HasKey(membership => new { membership.UserId, membership.MembershipCardId });


    modelBuilder.Entity<MomentVideo>(entity =>
    {
      entity.ToTable("MomentVideo");
     // entity.HasOne(d => d.Category)
     //.WithOne()
     //.OnDelete(DeleteBehavior.NoAction);

      //entity.HasOne(d => d.Match)
      //.WithOne()
      //.OnDelete(DeleteBehavior.NoAction);
    });

    modelBuilder.Entity<MediaPhoto>(entity =>
    {
      entity.ToTable("MediaPhoto");
     // entity.HasOne(d => d.Category)
     //.WithOne()
     //.OnDelete(DeleteBehavior.NoAction);

      entity.HasOne(d => d.Match)
      .WithMany()
      .OnDelete(DeleteBehavior.NoAction);
    });

    modelBuilder.Entity<NormalVideo>(entity =>
    {
      entity.ToTable("NormalVideo");
     // entity.HasOne(d => d.Category)
     //.WithOne()
     //.OnDelete(DeleteBehavior.NoAction);

      //entity.HasOne(d => d.Match)
      //.WithOne()
      //.OnDelete(DeleteBehavior.NoAction);
    });

    modelBuilder.Entity<Substitution>(entity =>
    {
      entity.ToTable("Substitution");
      entity.HasOne(d => d.Player)
     .WithOne()
     .OnDelete(DeleteBehavior.NoAction);

     entity.ToTable("Substitution");
      entity.HasOne(d => d.SubstitutionPlayer)
     .WithOne()
     .OnDelete(DeleteBehavior.NoAction);

      entity.HasOne(d => d.Match)
      .WithOne()
      .OnDelete(DeleteBehavior.NoAction);
    });

    modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
    modelBuilder.InitializeSeeds();
    modelBuilder.SeedMatchStatistics();
  }
  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_mediator == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
        .Select(e => e.Entity)
        .Where(e => e.Events.Any())
        .ToArray();

    foreach (var entity in entitiesWithEvents)
    {
      var events = entity.Events.ToArray();
      entity.Events.Clear();
      foreach (var domainEvent in events)
      {
        await _mediator.Publish(domainEvent).ConfigureAwait(false);
      }
    }

    return result;
  }
  public override int SaveChanges()
  {
    return SaveChangesAsync().GetAwaiter().GetResult();
  }
}
