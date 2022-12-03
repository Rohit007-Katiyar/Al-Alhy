using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AhliFans.WebApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BroadcastChannel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BroadcastChannel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    DateFrom = table.Column<DateTime>(type: "date", nullable: false),
                    DateTo = table.Column<DateTime>(type: "date", nullable: false),
                    TimeFrom = table.Column<TimeSpan>(type: "time", nullable: true),
                    TimeTo = table.Column<TimeSpan>(type: "time", nullable: true),
                    Description = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    DescriptionAr = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralPlayerPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralPlayerPosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegendBirthDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegendBirthDate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchEventType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchEventType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalAchievement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalAchievement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    TextAr = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrophyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrophyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsMotion = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Symbol = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    GeneralPositionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Position_GeneralPlayerPosition_GeneralPositionId",
                        column: x => x.GeneralPositionId,
                        principalTable: "GeneralPlayerPosition",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeagueDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeagueDates_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Referee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    NationalityId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referee_Countries_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Referee_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stadium",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadium", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stadium_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Logo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Team_TeamType",
                        column: x => x.TypeId,
                        principalTable: "TeamType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsSuperAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Admin_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Admin_User_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserCreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserModifiedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Season_User_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Season_User_UserModifiedId",
                        column: x => x.UserModifiedId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trophy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrophyTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trophy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trophy_TrophyType",
                        column: x => x.TrophyTypeId,
                        principalTable: "TrophyType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trophy_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trophy_User_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOtp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOtp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOtp_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coach",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    TeamCategoryId = table.Column<int>(type: "int", nullable: true),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    FirstNameAr = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    LastName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    LastNameAr = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateSigned = table.Column<DateTime>(type: "datetime", nullable: false),
                    Biography = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    BiographyAr = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Pic = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coach", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coach_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Coach_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Coach_TeamType_TeamCategoryId",
                        column: x => x.TeamCategoryId,
                        principalTable: "TeamType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Coach_Title",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Gender = table.Column<int>(type: "int", unicode: false, maxLength: 10, nullable: true),
                    ProfilePic = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Language = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    FireBaseToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedWith = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fan_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fan_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateSigned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Biography = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    BiographyAr = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Pic = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CityOfBirthId = table.Column<int>(type: "int", nullable: true),
                    CountryHeLiveIn = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    TeamCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Cities_CityOfBirthId",
                        column: x => x.CityOfBirthId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Player_Countries_CountryHeLiveIn",
                        column: x => x.CountryHeLiveIn,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Player_Position",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Player_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Player_TeamType_TeamCategoryId",
                        column: x => x.TeamCategoryId,
                        principalTable: "TeamType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Admin_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Admin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Category_Admin_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Jerseys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHome = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jerseys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jerseys_Admin_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Admin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jerseys_Admin_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchStatisticsType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchStatisticsType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchStatisticsType_Admin_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchStatisticsType_Admin_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Admin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MembershipCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Months = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembershipCards_Admin_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MembershipCards_Admin_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Admin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrophyHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrophyId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrophyHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrophyHistory_Trophy",
                        column: x => x.TrophyId,
                        principalTable: "Trophy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnableAll = table.Column<bool>(type: "bit", nullable: true),
                    PlaySounds = table.Column<bool>(type: "bit", nullable: true),
                    News = table.Column<bool>(type: "bit", nullable: true),
                    MatchStatus = table.Column<bool>(type: "bit", nullable: true),
                    NightMode = table.Column<bool>(type: "bit", nullable: true),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationSettings_Fan_FanId",
                        column: x => x.FanId,
                        principalTable: "Fan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Honor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrophyId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    CoachId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsPersonal = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    PersonalAchievementId = table.Column<int>(type: "int", nullable: true),
                    SeasonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Honor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Honor_Coach",
                        column: x => x.CoachId,
                        principalTable: "Coach",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Honor_PersonalAchievement_PersonalAchievementId",
                        column: x => x.PersonalAchievementId,
                        principalTable: "PersonalAchievement",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Honor_Player",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Honor_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Honor_Trophy_TrophyId",
                        column: x => x.TrophyId,
                        principalTable: "Trophy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTeam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    TeamTypeId = table.Column<int>(type: "int", nullable: false),
                    SignedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerTeam_Player",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialMediaAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoachId = table.Column<int>(type: "int", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    SocialMediaAccount = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerSocialMediaAccount_Player",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SocialMediaAccount_Coach",
                        column: x => x.CoachId,
                        principalTable: "Coach",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    OpponentTeamId = table.Column<int>(type: "int", nullable: false),
                    StadiumId = table.Column<int>(type: "int", nullable: false),
                    RefereeId = table.Column<int>(type: "int", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    LeagueDateId = table.Column<int>(type: "int", nullable: true),
                    JerseyId = table.Column<int>(type: "int", nullable: true),
                    BroadcastChannelId = table.Column<int>(type: "int", nullable: true),
                    IsAway = table.Column<bool>(type: "bit", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: true),
                    OpponentScore = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    MatchType = table.Column<int>(type: "int", nullable: false),
                    MatchStatus = table.Column<int>(type: "int", nullable: true),
                    ActualDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlannedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_BroadcastChannel_BroadcastChannelId",
                        column: x => x.BroadcastChannelId,
                        principalTable: "BroadcastChannel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Jerseys_JerseyId",
                        column: x => x.JerseyId,
                        principalTable: "Jerseys",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_LeagueDates_LeagueDateId",
                        column: x => x.LeagueDateId,
                        principalTable: "LeagueDates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_Refere",
                        column: x => x.RefereeId,
                        principalTable: "Referee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Season",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Stadium",
                        column: x => x.StadiumId,
                        principalTable: "Stadium",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Team",
                        column: x => x.OpponentTeamId,
                        principalTable: "Team",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchStatisticsTypeCoefficient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchStatisticsTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsPercentage = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchStatisticsTypeCoefficient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchStatisticsTypeCoefficient_Admin_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchStatisticsTypeCoefficient_Admin_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchStatisticsTypeCoefficient_MatchStatisticsType",
                        column: x => x.MatchStatisticsTypeId,
                        principalTable: "MatchStatisticsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMemberships",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MembershipCardId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMemberships", x => new { x.UserId, x.MembershipCardId });
                    table.ForeignKey(
                        name: "FK_UserMemberships_Fan_UserId",
                        column: x => x.UserId,
                        principalTable: "Fan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMemberships_MembershipCards_MembershipCardId",
                        column: x => x.MembershipCardId,
                        principalTable: "MembershipCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FanNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    Read = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FanNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FanNotifications_Fan_FanId",
                        column: x => x.FanId,
                        principalTable: "Fan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FanNotifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FanPreference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    LocalTrophyId = table.Column<int>(type: "int", nullable: true),
                    AfricanTrophyId = table.Column<int>(type: "int", nullable: true),
                    MatchId = table.Column<int>(type: "int", nullable: true),
                    FavoritePlayerAllTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FavoriteCoachAllTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FavoriteMoment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    CoachId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FanPreference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FanPreference_Coach_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coach",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FanPreference_Fan",
                        column: x => x.FanId,
                        principalTable: "Fan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FanPreference_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FanPreference_Player",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FanPreference_Trophy_AfricanTrophyId",
                        column: x => x.AfricanTrophyId,
                        principalTable: "Trophy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FanPreference_Trophy_LocalTrophyId",
                        column: x => x.LocalTrophyId,
                        principalTable: "Trophy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchBroadcastChannels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    ChannelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchBroadcastChannels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchBroadcastChannels_BroadcastChannel",
                        column: x => x.ChannelId,
                        principalTable: "BroadcastChannel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchBroadcastChannels_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchesCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Minute = table.Column<int>(type: "int", nullable: false),
                    IsRed = table.Column<bool>(type: "bit", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsForAhly = table.Column<bool>(type: "bit", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchesCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchesCards_Admin_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchesCards_Admin_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchesCards_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchesCards_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchesGoals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    Minute = table.Column<int>(type: "int", nullable: false),
                    IsForAhly = table.Column<bool>(type: "bit", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminCreateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AdminModifyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchesGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchesGoals_Admin_AdminCreateId",
                        column: x => x.AdminCreateId,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchesGoals_Admin_AdminModifyId",
                        column: x => x.AdminModifyId,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchesGoals_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchesGoals_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchEventTypeId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    Minute = table.Column<int>(type: "int", nullable: false),
                    IsSecondHalf = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchEvent_Match",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchEvent_MatchEventType",
                        column: x => x.MatchEventTypeId,
                        principalTable: "MatchEventType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchLineUp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    IsSubstitute = table.Column<bool>(type: "bit", nullable: false),
                    X = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Y = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchLineUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchLineUp_Match",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchLineUp_Player",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchLineUp_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaType = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchMedia_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchPlayers_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchPlayers_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchTag_Match",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchTag_Tags",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MediaPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    CoachId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsExclusiveContent = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaPhoto_Admin_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Admin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaPhoto_Admin_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaPhoto_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaPhoto_Coach_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coach",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaPhoto_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaPhoto_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaPhoto_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaPhoto_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    MomentTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MediaFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moments_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Moments_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MomentVideo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    VideoType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MomentVideo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MomentVideo_Admin_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Admin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MomentVideo_Admin_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MomentVideo_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MomentVideo_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MomentVideo_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MomentVideo_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MomentVideo_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NormalVideo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    CoachId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalVideo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NormalVideo_Admin_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Admin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NormalVideo_Admin_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NormalVideo_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NormalVideo_Coach_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coach",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NormalVideo_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NormalVideo_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NormalVideo_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NormalVideo_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerVotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    FanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerVotes_Fan_FanId",
                        column: x => x.FanId,
                        principalTable: "Fan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerVotes_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerVotes_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SquadList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SquadList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SquadList_Admin_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SquadList_Admin_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SquadList_Match",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SquadList_Player",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Substitution",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    SubstitutionPlayerId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Substitution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Substitution_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Substitution_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Substitution_Player_SubstitutionPlayerId",
                        column: x => x.SubstitutionPlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    StatisticsTypeId = table.Column<int>(type: "int", nullable: false),
                    StatisticsCoefficientId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchStatistics_Admin_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchStatistics_Admin_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchStatistics_Match",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchStatistics_MatchStatisticsType",
                        column: x => x.StatisticsTypeId,
                        principalTable: "MatchStatisticsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchStatistics_MatchStatisticsTypeCoefficient",
                        column: x => x.StatisticsCoefficientId,
                        principalTable: "MatchStatisticsTypeCoefficient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MediaTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LegendId = table.Column<int>(type: "int", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    CoachId = table.Column<int>(type: "int", nullable: true),
                    MatchEventId = table.Column<int>(type: "int", nullable: true),
                    PhotoId = table.Column<int>(type: "int", nullable: true),
                    VideoId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaTag_Coach",
                        column: x => x.CoachId,
                        principalTable: "Coach",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaTag_LegendBirthDate",
                        column: x => x.LegendId,
                        principalTable: "LegendBirthDate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaTag_MatchEvent",
                        column: x => x.MatchEventId,
                        principalTable: "MatchEvent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerTag_Photo",
                        column: x => x.PhotoId,
                        principalTable: "Photo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerTag_Player",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerTag_Video",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MomentVotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MomentId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MomentVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MomentVotes_Fan_FanId",
                        column: x => x.FanId,
                        principalTable: "Fan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MomentVotes_Moments_MomentId",
                        column: x => x.MomentId,
                        principalTable: "Moments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[] { 1, "Egypt", "مصر" });

            migrationBuilder.InsertData(
                table: "GeneralPlayerPosition",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, "Goalkeepers", "حراس المرمي" },
                    { 2, "Defenders", "مدافعين" },
                    { 3, "Midfielder", "وسط ملعب" },
                    { 4, "Attackers", "مهاجمين" }
                });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "Date", "IsDeleted", "Name", "NameAr" },
                values: new object[] { 1, new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "League Championship", "بطوله الدوري" });

            migrationBuilder.InsertData(
                table: "MatchStatisticsType",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsEnabled", "ModifiedBy", "ModifiedOn", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7214), true, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7226), "General", "عام" },
                    { 2, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7232), false, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7233), "Attacking", "هجوم" },
                    { 3, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7235), false, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7235), "Defending", "دفاع" }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Date", "Isdeleted", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Local", "محلي" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "African", "افريقي" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "International", "دولي" }
                });

            migrationBuilder.InsertData(
                table: "Season",
                columns: new[] { "Id", "CreationDate", "EndDate", "IsDeleted", "ModifiedDate", "Name", "NameAr", "StartDate", "UserCreatedId", "UserModifiedId" },
                values: new object[] { 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Egyptian League", "الدوري المصري", new DateTime(2019, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.InsertData(
                table: "Stadium",
                columns: new[] { "Id", "Date", "IsDeleted", "Location", "Name", "NameAr", "RegionId" },
                values: new object[] { 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Cairo International Stadium", "استاد القاهره الدولي", null });

            migrationBuilder.InsertData(
                table: "TeamType",
                columns: new[] { "Id", "IsDeleted", "Name", "NameAr" },
                values: new object[] { 1, false, "Egyptian Team", "فريق مصري" });

            migrationBuilder.InsertData(
                table: "Title",
                columns: new[] { "Id", "Date", "IsDeleted", "Text", "TextAr" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Coach", "مدير فني" },
                    { 2, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Football Manager", "مدير كرة القدم" }
                });

            migrationBuilder.InsertData(
                table: "TrophyType",
                columns: new[] { "Id", "Date", "IsDeleted", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Local Trophy", "ذكري محلية" },
                    { 2, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "African Trophy", "ذكري افريقية" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, 1, "Cairo", "القاهرة" },
                    { 2, 1, "Al-Qalyubia", "القليوبية" },
                    { 3, 1, "Giza", "الجيزة" }
                });

            migrationBuilder.InsertData(
                table: "LeagueDates",
                columns: new[] { "Id", "IsDeleted", "LeagueId", "Year" },
                values: new object[,]
                {
                    { 1, false, 1, 2012 },
                    { 2, false, 1, 2018 },
                    { 3, false, 1, 2020 }
                });

            migrationBuilder.InsertData(
                table: "MatchStatisticsTypeCoefficient",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsPercentage", "MatchStatisticsTypeId", "ModifiedBy", "ModifiedOn", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7289), true, 1, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7290), "Possession", "استحواذ" },
                    { 2, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7294), false, 1, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7295), "Shots On Target", "تسديدات علي المرمي" },
                    { 3, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7297), false, 1, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7298), "Passes", "تمريرات" },
                    { 4, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7300), false, 1, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7306), "Corners", "ركنيات" },
                    { 5, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7307), false, 1, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7308), "Free Kicks", "ضربات حرة" },
                    { 6, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7312), false, 2, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7313), "Penalties", "ضربات الجزاء" },
                    { 7, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7315), true, 2, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7316), "Pass Accuracy", "دقة التمريرات" },
                    { 8, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7318), false, 2, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7318), "Chances Created", "اتاحة فرص" },
                    { 9, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7320), false, 2, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7321), "Crosses", "تقاطعات" },
                    { 10, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7327), true, 2, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7328), "Crosses Success", "تقاطعات ناجحة" },
                    { 11, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7331), false, 3, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7332), "Tackles Made", "تدخلات مصنوعة" },
                    { 12, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7337), false, 3, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7346), "Interceptions", "اعتراضات" },
                    { 13, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7348), false, 3, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7349), "Blocked sheets", "تصديات" },
                    { 14, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7351), false, 3, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7352), "Clearances", "تخليص" },
                    { 15, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7354), false, 3, null, new DateTime(2022, 9, 8, 21, 53, 54, 22, DateTimeKind.Local).AddTicks(7354), "Goalkeeper Saves", "انقاذات حارس المرمي" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "Id", "Date", "GeneralPositionId", "IsDeleted", "Name", "NameAr", "Symbol" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "GoalKeeper", "حارس مرمي", "GK" },
                    { 2, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false, "Center Forward", "مهاجم", "CF" },
                    { 3, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false, "Right Wing", "جناح ايمن", "RW" },
                    { 4, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false, "Left Wing", "جناح ايسر", "LW" },
                    { 5, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, "Right Back", "مدافع ايمن", "RB" },
                    { 6, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, "Left Back", "مدافع ايسر", "LB" },
                    { 7, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, "Center Back", "قلب دفاع", "CB" },
                    { 8, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, "Center Midfielder", "وسط ملعب", "CM" },
                    { 9, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, "Defensive Midfielder", "وسط مدافع", "DM" },
                    { 10, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, "Attacking Midfielder", "وسط مهاجم", "AM" }
                });

            migrationBuilder.InsertData(
                table: "Referee",
                columns: new[] { "Id", "Date", "IsDeleted", "Name", "NameAr", "NationalityId", "RegionId" },
                values: new object[] { 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Gehad Gresha", "جهاد جريشه", 1, null });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "Id", "Date", "IsDeleted", "Logo", "Name", "NameAr", "RegionId", "TypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "El Zamalek", "الزمالك", null, 1 },
                    { 2, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "El Asmaily", "الاسماعيلي", null, 1 },
                    { 3, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "El Masry", "المصري", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Trophy",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsAvailable", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name", "NameAr", "Picture", "TrophyTypeId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, "Egyptian League", "الدوري المصري", null, 1 },
                    { 2, null, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, "African Cup", "دوري ابطال افريقيا", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Coach",
                columns: new[] { "Id", "Biography", "BiographyAr", "BirthDate", "CityId", "CountryId", "Date", "DateSigned", "FirstName", "FirstNameAr", "IsCurrent", "IsDeleted", "LastName", "LastNameAr", "Pic", "TeamCategoryId", "TitleId" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(1960, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pitso", "بيتسو", false, false, "Mosimane", "موسيماني", "pitso-mosimane.png", null, 1 },
                    { 2, null, null, new DateTime(1960, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ricardo", "ريكاردو", true, false, "Suarez", "سواريز", null, null, 1 },
                    { 3, null, null, new DateTime(1960, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Syed ", "سيد", true, false, "Abdul Hafeez", "عبد الحفيظ", null, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Match",
                columns: new[] { "Id", "ActualDate", "ActualTime", "BroadcastChannelId", "Date", "IsAvailable", "IsAway", "IsDeleted", "JerseyId", "LeagueDateId", "LeagueId", "MatchStatus", "MatchType", "OpponentScore", "OpponentTeamId", "PlannedDate", "PlannedTime", "RefereeId", "Score", "SeasonId", "StadiumId", "Time" },
                values: new object[,]
                {
                    { 1, null, null, null, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, null, 1, 1, null, 2, 2, 1, new DateTime(2012, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "9:30Pm", 1, 3, 1, 1, "90" },
                    { 2, null, null, null, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, null, 1, 1, null, 2, 2, 1, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "9:30Pm", 1, 3, 1, 1, "90" },
                    { 3, null, null, null, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, null, 1, 1, null, 2, 2, 1, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "9:30Pm", 1, 3, 1, 1, "90" },
                    { 4, null, null, null, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, null, 1, 1, null, 1, 2, 1, new DateTime(2022, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "9:30Pm", 1, 3, 1, 1, "90" },
                    { 5, null, null, null, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, null, 1, 1, null, 2, 2, 3, new DateTime(2012, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "9:30Pm", 1, 3, 1, 1, "90" },
                    { 6, null, null, null, new DateTime(2022, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, null, 2, 1, null, 0, null, 2, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "9:30Pm", 1, null, 1, 1, "90" },
                    { 7, null, null, null, new DateTime(2022, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, null, 2, 1, null, 0, null, 1, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "9:30Pm", 1, null, 1, 1, "90" },
                    { 8, null, null, null, new DateTime(2022, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, null, 3, 1, null, 0, null, 3, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "9:30Pm", 1, null, 1, 1, "90" }
                });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "Id", "Biography", "BiographyAr", "BirthDate", "CityOfBirthId", "CountryHeLiveIn", "Date", "DateSigned", "Height", "IsDeleted", "Name", "NameAr", "Number", "Pic", "PositionId", "TeamCategoryId", "TeamId", "Weight" },
                values: new object[,]
                {
                    { 1, "He is Egypt's best goalkeeper and was raised in Al Ahly as one of our homegrown players.He left the club to gain more experience and playtime in different Egyptian teams.After his great performance, he rejoined Al Ahly and proved himself as one of the top goalkeepers in Egypt. El Shenawy represented our national team in 2018 World Cup after his second season with AlAhly.", null, new DateTime(1988, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 191, false, "Mohamed El-Shinawy", "محمد الشناوي", 1, "shinawy.png", 1, null, null, 86 },
                    { 2, null, null, new DateTime(1988, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, false, "Ali Malol", "علي معلول", 11, "malol.png", 5, null, null, 71 },
                    { 3, null, null, new DateTime(1994, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, false, "Percy Tau", "بيرسي تاو", 23, null, 3, null, null, 71 },
                    { 4, null, null, new DateTime(1994, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, false, "Ahmed Abd-Elqader", "أحمد القادر", 35, null, 4, null, null, 71 },
                    { 5, null, null, new DateTime(1994, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, false, "Mohamed Sherif", "محمد شريف", 10, null, 2, null, null, 71 },
                    { 6, null, null, new DateTime(1994, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, false, "Hamdi Fathy", "حمدي فتحي", 8, null, 8, null, null, 71 },
                    { 7, null, null, new DateTime(1994, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, false, "Yasser Ibrahim", "ياسر إبراهيم", 6, null, 7, null, null, 71 },
                    { 8, null, null, new DateTime(1994, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, false, "Rami Rabiea", "رامي ربيعة", 5, null, 7, null, null, 71 },
                    { 9, null, null, new DateTime(1994, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, false, "Mohamed Hany", "محمد هاني", 30, null, 6, null, null, 71 },
                    { 10, null, null, new DateTime(1994, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, false, "Amr Al-Sulayya", "عمرو السولية", 17, null, 9, null, null, 71 },
                    { 11, null, null, new DateTime(1994, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, false, "Magdy Qafsha", "محمد مجدي قفشه", 19, null, 10, null, null, 71 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_CreatedBy",
                table: "Admin",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_ModifiedBy",
                table: "Admin",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CreatedById",
                table: "Category",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ModifiedById",
                table: "Category",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Coach_CityId",
                table: "Coach",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Coach_CountryId",
                table: "Coach",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Coach_TeamCategoryId",
                table: "Coach",
                column: "TeamCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Coach_TitleId",
                table: "Coach",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Fan_CityId",
                table: "Fan",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_FanNotifications_FanId",
                table: "FanNotifications",
                column: "FanId");

            migrationBuilder.CreateIndex(
                name: "IX_FanNotifications_NotificationId",
                table: "FanNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_FanPreference_AfricanTrophyId",
                table: "FanPreference",
                column: "AfricanTrophyId");

            migrationBuilder.CreateIndex(
                name: "IX_FanPreference_CoachId",
                table: "FanPreference",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_FanPreference_FanId",
                table: "FanPreference",
                column: "FanId");

            migrationBuilder.CreateIndex(
                name: "IX_FanPreference_LocalTrophyId",
                table: "FanPreference",
                column: "LocalTrophyId");

            migrationBuilder.CreateIndex(
                name: "IX_FanPreference_MatchId",
                table: "FanPreference",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FanPreference_PlayerId",
                table: "FanPreference",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Honor_CoachId",
                table: "Honor",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Honor_PersonalAchievementId",
                table: "Honor",
                column: "PersonalAchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_Honor_PlayerId",
                table: "Honor",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Honor_SeasonId",
                table: "Honor",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Honor_TrophyId",
                table: "Honor",
                column: "TrophyId");

            migrationBuilder.CreateIndex(
                name: "IX_Jerseys_CreatedById",
                table: "Jerseys",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Jerseys_ModifiedById",
                table: "Jerseys",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueDates_LeagueId",
                table: "LeagueDates",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_BroadcastChannelId",
                table: "Match",
                column: "BroadcastChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_JerseyId",
                table: "Match",
                column: "JerseyId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_LeagueDateId",
                table: "Match",
                column: "LeagueDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_LeagueId",
                table: "Match",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_OpponentTeamId",
                table: "Match",
                column: "OpponentTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_RefereeId",
                table: "Match",
                column: "RefereeId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_SeasonId",
                table: "Match",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_StadiumId",
                table: "Match",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchBroadcastChannels_ChannelId",
                table: "MatchBroadcastChannels",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchBroadcastChannels_MatchId",
                table: "MatchBroadcastChannels",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchesCards_CreatedBy",
                table: "MatchesCards",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MatchesCards_MatchId",
                table: "MatchesCards",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchesCards_ModifiedBy",
                table: "MatchesCards",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MatchesCards_PlayerId",
                table: "MatchesCards",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchesGoals_AdminCreateId",
                table: "MatchesGoals",
                column: "AdminCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchesGoals_AdminModifyId",
                table: "MatchesGoals",
                column: "AdminModifyId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchesGoals_MatchId",
                table: "MatchesGoals",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchesGoals_PlayerId",
                table: "MatchesGoals",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchEvent_MatchEventTypeId",
                table: "MatchEvent",
                column: "MatchEventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchEvent_MatchId",
                table: "MatchEvent",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchLineUp_MatchId",
                table: "MatchLineUp",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchLineUp_PlayerId",
                table: "MatchLineUp",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchLineUp_PositionId",
                table: "MatchLineUp",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchMedia_MatchId",
                table: "MatchMedia",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayers_MatchId",
                table: "MatchPlayers",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayers_PlayerId",
                table: "MatchPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatistics_CreatedBy",
                table: "MatchStatistics",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatistics_MatchId",
                table: "MatchStatistics",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatistics_ModifiedBy",
                table: "MatchStatistics",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatistics_StatisticsCoefficientId",
                table: "MatchStatistics",
                column: "StatisticsCoefficientId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatistics_StatisticsTypeId",
                table: "MatchStatistics",
                column: "StatisticsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatisticsType_CreatedBy",
                table: "MatchStatisticsType",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatisticsType_ModifiedBy",
                table: "MatchStatisticsType",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatisticsType_Name",
                table: "MatchStatisticsType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatisticsType_NameAr",
                table: "MatchStatisticsType",
                column: "NameAr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatisticsTypeCoefficient_CreatedBy",
                table: "MatchStatisticsTypeCoefficient",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatisticsTypeCoefficient_MatchStatisticsTypeId",
                table: "MatchStatisticsTypeCoefficient",
                column: "MatchStatisticsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatisticsTypeCoefficient_ModifiedBy",
                table: "MatchStatisticsTypeCoefficient",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatisticsTypeCoefficient_Name",
                table: "MatchStatisticsTypeCoefficient",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatisticsTypeCoefficient_NameAr",
                table: "MatchStatisticsTypeCoefficient",
                column: "NameAr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchTag_MatchId",
                table: "MatchTag",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchTag_TagId",
                table: "MatchTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaPhoto_CategoryId",
                table: "MediaPhoto",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaPhoto_CoachId",
                table: "MediaPhoto",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaPhoto_CreatedById",
                table: "MediaPhoto",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MediaPhoto_LeagueId",
                table: "MediaPhoto",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaPhoto_MatchId",
                table: "MediaPhoto",
                column: "MatchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaPhoto_ModifiedById",
                table: "MediaPhoto",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_MediaPhoto_PlayerId",
                table: "MediaPhoto",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaPhoto_SeasonId",
                table: "MediaPhoto",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaTag_CoachId",
                table: "MediaTag",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaTag_LegendId",
                table: "MediaTag",
                column: "LegendId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaTag_MatchEventId",
                table: "MediaTag",
                column: "MatchEventId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaTag_PhotoId",
                table: "MediaTag",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaTag_PlayerId",
                table: "MediaTag",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaTag_VideoId",
                table: "MediaTag",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipCards_CreatedBy",
                table: "MembershipCards",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipCards_ModifiedBy",
                table: "MembershipCards",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Moments_MatchId",
                table: "Moments",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Moments_PlayerId",
                table: "Moments",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MomentVideo_CategoryId",
                table: "MomentVideo",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MomentVideo_CreatedById",
                table: "MomentVideo",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MomentVideo_LeagueId",
                table: "MomentVideo",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_MomentVideo_MatchId",
                table: "MomentVideo",
                column: "MatchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MomentVideo_ModifiedById",
                table: "MomentVideo",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_MomentVideo_PlayerId",
                table: "MomentVideo",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MomentVideo_SeasonId",
                table: "MomentVideo",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_MomentVotes_FanId",
                table: "MomentVotes",
                column: "FanId");

            migrationBuilder.CreateIndex(
                name: "IX_MomentVotes_MomentId",
                table: "MomentVotes",
                column: "MomentId");

            migrationBuilder.CreateIndex(
                name: "IX_NormalVideo_CategoryId",
                table: "NormalVideo",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NormalVideo_CoachId",
                table: "NormalVideo",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_NormalVideo_CreatedById",
                table: "NormalVideo",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_NormalVideo_LeagueId",
                table: "NormalVideo",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_NormalVideo_MatchId",
                table: "NormalVideo",
                column: "MatchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NormalVideo_ModifiedById",
                table: "NormalVideo",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_NormalVideo_PlayerId",
                table: "NormalVideo",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_NormalVideo_SeasonId",
                table: "NormalVideo",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AdminId",
                table: "Notifications",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationSettings_FanId",
                table: "NotificationSettings",
                column: "FanId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_CityOfBirthId",
                table: "Player",
                column: "CityOfBirthId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_CountryHeLiveIn",
                table: "Player",
                column: "CountryHeLiveIn");

            migrationBuilder.CreateIndex(
                name: "IX_Player_PositionId",
                table: "Player",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamCategoryId",
                table: "Player",
                column: "TeamCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeam_PlayerId",
                table: "PlayerTeam",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerVotes_FanId",
                table: "PlayerVotes",
                column: "FanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerVotes_MatchId",
                table: "PlayerVotes",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerVotes_PlayerId",
                table: "PlayerVotes",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_GeneralPositionId",
                table: "Position",
                column: "GeneralPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Referee_NationalityId",
                table: "Referee",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Referee_RegionId",
                table: "Referee",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Season_UserCreatedId",
                table: "Season",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Season_UserModifiedId",
                table: "Season",
                column: "UserModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediaAccount_CoachId",
                table: "SocialMediaAccount",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediaAccount_PlayerId",
                table: "SocialMediaAccount",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadList_CreatedBy",
                table: "SquadList",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SquadList_MatchId",
                table: "SquadList",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_SquadList_ModifiedBy",
                table: "SquadList",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SquadList_PlayerId",
                table: "SquadList",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Stadium_RegionId",
                table: "Stadium",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Substitution_MatchId",
                table: "Substitution",
                column: "MatchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Substitution_PlayerId",
                table: "Substitution",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Substitution_SubstitutionPlayerId",
                table: "Substitution",
                column: "SubstitutionPlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_RegionId",
                table: "Team",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_TypeId",
                table: "Team",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trophy_CreatedBy",
                table: "Trophy",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Trophy_ModifiedBy",
                table: "Trophy",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Trophy_TrophyTypeId",
                table: "Trophy",
                column: "TrophyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrophyHistory_TrophyId",
                table: "TrophyHistory",
                column: "TrophyId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMemberships_MembershipCardId",
                table: "UserMemberships",
                column: "MembershipCardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOtp_UserId",
                table: "UserOtp",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "FanNotifications");

            migrationBuilder.DropTable(
                name: "FanPreference");

            migrationBuilder.DropTable(
                name: "Honor");

            migrationBuilder.DropTable(
                name: "MatchBroadcastChannels");

            migrationBuilder.DropTable(
                name: "MatchesCards");

            migrationBuilder.DropTable(
                name: "MatchesGoals");

            migrationBuilder.DropTable(
                name: "MatchLineUp");

            migrationBuilder.DropTable(
                name: "MatchMedia");

            migrationBuilder.DropTable(
                name: "MatchPlayers");

            migrationBuilder.DropTable(
                name: "MatchStatistics");

            migrationBuilder.DropTable(
                name: "MatchTag");

            migrationBuilder.DropTable(
                name: "MediaPhoto");

            migrationBuilder.DropTable(
                name: "MediaTag");

            migrationBuilder.DropTable(
                name: "MomentVideo");

            migrationBuilder.DropTable(
                name: "MomentVotes");

            migrationBuilder.DropTable(
                name: "NormalVideo");

            migrationBuilder.DropTable(
                name: "NotificationSettings");

            migrationBuilder.DropTable(
                name: "PlayerTeam");

            migrationBuilder.DropTable(
                name: "PlayerVotes");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "SocialMediaAccount");

            migrationBuilder.DropTable(
                name: "SquadList");

            migrationBuilder.DropTable(
                name: "Substitution");

            migrationBuilder.DropTable(
                name: "TrophyHistory");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserMemberships");

            migrationBuilder.DropTable(
                name: "UserOtp");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PersonalAchievement");

            migrationBuilder.DropTable(
                name: "MatchStatisticsTypeCoefficient");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "LegendBirthDate");

            migrationBuilder.DropTable(
                name: "MatchEvent");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Moments");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Coach");

            migrationBuilder.DropTable(
                name: "Trophy");

            migrationBuilder.DropTable(
                name: "Fan");

            migrationBuilder.DropTable(
                name: "MembershipCards");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "MatchStatisticsType");

            migrationBuilder.DropTable(
                name: "MatchEventType");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "TrophyType");

            migrationBuilder.DropTable(
                name: "BroadcastChannel");

            migrationBuilder.DropTable(
                name: "Jerseys");

            migrationBuilder.DropTable(
                name: "LeagueDates");

            migrationBuilder.DropTable(
                name: "Referee");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropTable(
                name: "Stadium");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "GeneralPlayerPosition");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "TeamType");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
