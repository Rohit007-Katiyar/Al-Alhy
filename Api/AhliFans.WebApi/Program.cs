using System.Text;
using AhliFans.Core;
using AhliFans.Core.Feature.Security.Entities;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Infrastructure;
using AhliFans.Infrastructure.Data;
using AhliFans.WebApi.Filters;
using Ardalis.ListStartupServices;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ExtCore.FileStorage;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using AhliFans.Core.Feature.Security.Token.JWTHelpers;
using AhliFans.Core.Feature.Security.Utilities.DigitsSecurityProvider;
using AhliFans.SharedKernel.APIServices.FaceBook.IRepository;
using AhliFans.SharedKernel.APIServices.FaceBook.Repository;
using AhliFans.SharedKernel.APIServices.FaceBook.Settings;
using AhliFans.SharedKernel.Logging;
using Microsoft.AspNetCore.Mvc;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.APIServices.Cequens.IRepository;
using AhliFans.SharedKernel.APIServices.Cequens.Repository;
using AhliFans.SharedKernel.APIServices.Cequens.Settings;
using AhliFans.SharedKernel.APIServices.Fawry.IRepository;
using AhliFans.SharedKernel.APIServices.Fawry.Repository;
using AhliFans.SharedKernel.APIServices.Fawry.Settings;
using AhliFans.SharedKernel.APIServices.Notification.Repo;
using FirebaseAdmin;
using AhliFans.SharedKernel.Interfaces;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
#region logging

Log.Logger = new LoggerConfiguration()
  .WriteTo
  .Console()
  .CreateBootstrapLogger();

builder
  .Host
  .UseSerilog((ctx, lc) => lc
    .WriteTo
    .Console()
    .ReadFrom
    .Configuration(ctx.Configuration));

#endregion  
#region security

builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
builder.Services.AddScoped<JWTToken>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var clientPolicy = new AuthorizationPolicyBuilder()
                 .RequireAuthenticatedUser()
                 .RequireRole(nameof(Roles.Fan))
                 .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                 .Build();

var adminPolicy = new AuthorizationPolicyBuilder()
                 .RequireAuthenticatedUser()
                 .RequireRole(nameof(Roles.Admin))
                 .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                 .Build();

builder
    .Services
    .AddIdentity<User, Role>(o =>
    {
      o.User.RequireUniqueEmail = true;
      o.SignIn.RequireConfirmedEmail = false;
      o.Password.RequireDigit = false;
      o.Password.RequiredLength = 3;
      o.Password.RequireLowercase = false;
      o.Password.RequireNonAlphanumeric = false;
      o.Password.RequireUppercase = false;
    })
    .AddRoles<Role>()
    .AddTokenProvider<FourDigitTokenProvider>(FourDigitTokenProvider.FourDigitEmail)
    .AddTokenProvider<FourDigitTokenProvider>(FourDigitTokenProvider.FourDigitPhone)
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddIdentityCore<Admin>()
  .AddRoles<Role>()
  .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddIdentityCore<Fan>()
  .AddRoles<Role>()
  .AddEntityFrameworkStores<AppDbContext>();

builder.Services
       .AddAuthorization(o =>
       {
         o.AddPolicy(nameof(Roles.Fan), clientPolicy);
         o.AddPolicy(nameof(Roles.Admin), adminPolicy);
       });

builder
.Services
.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
  options.TokenValidationParameters = new TokenValidationParameters()
  {
    ValidateActor = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["JWT:Issuer"],
    ValidAudience = builder.Configuration["JWT:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
  };
});
//FaceBook services
var faceBookAuthSetting = new FaceBookAuthSettings();
builder.Configuration.Bind(nameof(FaceBookAuthSettings), faceBookAuthSetting);
builder.Services.AddSingleton(faceBookAuthSetting);
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IFaceBookAuthService, FaceBookAuthService>();

//Cequens service
builder.Services.Configure<CequensSettings>(builder.Configuration.GetSection("Cequens"));
builder.Services.AddScoped<ICequensService, CequensService>();

//Fawry service
builder.Services.Configure<FawrySettings>(builder.Configuration.GetSection("Fawry"));
builder.Services.AddTransient<IFawryPaymentService, FawryPaymentService>();

#endregion
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.Configure<CookiePolicyOptions>(options =>
{
  options.CheckConsentNeeded = _ => true;
  options.MinimumSameSitePolicy = SameSiteMode.None;
});

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//FireBase service
FirebaseApp.Create(new AppOptions()
{
  Credential = GoogleCredential.FromFile("private_key.json")
});
builder.Services.AddSingleton<INotificationService, NotificationService>();


builder.Services.AddDbContext(connectionString);
builder.Services.Configure<ConnectionHolder>(config => config.Connection = connectionString);

#region Policies



#endregion

builder.Services
  .AddMvc()
  .AddFluentValidation(fv =>
  {
    fv.AutomaticValidationEnabled = false;
    fv.ImplicitlyValidateRootCollectionElements = true;
    fv.ImplicitlyValidateChildProperties = true;
    fv.RegisterValidatorsFromAssemblyContaining<DefaultCoreModule>();
  });

builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddRazorPages();
 
builder.Services.AddSwaggerGen(c =>
{
  c.OperationFilter<SwaggerAuthorizeOperationFilter>();
  c.DocInclusionPredicate((_, api) => _ == api.GroupName);
  c.SwaggerDoc(nameof(Areas.Admin), new OpenApiInfo { Title = "Ahli-Fans Admin", Version = "v1" });
  c.SwaggerDoc(nameof(Areas.Client), new OpenApiInfo { Title = "Ahli-Fans Client", Version = "v1" });
  c.EnableAnnotations();
  c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
  {
    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
    Name = "Authorization",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
    Scheme = "Bearer"
  });
});

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
  containerBuilder.RegisterModule(new DefaultCoreModule());
  containerBuilder.RegisterModule(new DefaultInfrastructureModule(builder.Environment.EnvironmentName == "Development"));
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.Configure<FileStorageOptions>(options =>
{
  options.RootPath = $"{builder.Environment.ContentRootPath}\\wwwroot";
});

builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
  opt.InvalidModelStateResponseFactory = context =>
  {
    var modelState = context.ModelState;
    var errors = modelState.Values.SelectMany(v => v.Errors);
    var errorMessages = errors.Select(e => e.ErrorMessage);
    var response = new EndPointResponse("AlAhly", string.Join(", ", errorMessages), AhliFans.SharedKernel.Enum.ResponseStatus.Error);
    return new BadRequestObjectResult(response);
  };
});

var app = builder.Build();// .MigrateDatabase();

//app.MigrateDatabase();
app.UseCors(
  options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
);
if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseShowAllServicesMiddleware();
}
else
{
  app.UseHsts();
}
app.UseAppException();

app.UseRouting();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.UseCookiePolicy();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
  c.SwaggerEndpoint($"../swagger/Admin/swagger.json", "Ahli-Fans Administration API V1");
  c.SwaggerEndpoint($"../swagger/Client/swagger.json", "Ahli-Fans Web API V1");
});

app.UseEndpoints((c) =>
{
  c.MapControllers();
  c.MapSwagger();
});

using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;

  try
  {
    var context = services.GetRequiredService<AppDbContext>();
   
    context.Database.Migrate();
    // await InitDefaultSeed.Initialize(services);
    // await CountriesSeeds.Initialize(services);
  }
  catch (Exception ex)
  {
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred seeding the DB.");
  }
}
app.Run();
