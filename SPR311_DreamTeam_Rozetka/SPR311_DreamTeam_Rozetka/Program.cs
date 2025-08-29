using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SPR311_DreamTeam_Rozetka.BLL.Services.Image;
using SPR311_DreamTeam_Rozetka.BLL.Services.User;
using SPR311_DreamTeam_Rozetka.BLL.Services.Account;
using SPR311_DreamTeam_Rozetka.BLL.Services.Role;
using SPR311_DreamTeam_Rozetka.DAL;
using SPR311_DreamTeam_Rozetka.DAL.Entities.Identity;
using SPR311_DreamTeam_Rozetka.BLL.Services.JwtToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Reflection;
using SPR311_DreamTeam_Rozetka.BLL.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using SPR311_DreamTeam_Rozetka.BLL.Validators.Account;
using Microsoft.Extensions.FileProviders;
using SPR311_DreamTeam_Rozetka.BLL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

//Add fluent validation
builder.Services.AddValidatorsFromAssemblyContaining<RegisterValdator>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql("name=PostgresLocal");
});

//Add Jwt
string secretkey = builder.Configuration["JwtSettings:SecretKey"]
    ?? throw new ArgumentNullException("Jwt secret key is null");
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            RequireExpirationTime = true,
            ClockSkew = TimeSpan.Zero,
            ValidAudience = builder.Configuration["JwtSettings: Audience"],
            ValidIssuer = builder.Configuration["JwtSettings: Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey))
        };
    });

//Jwt settings
var jwtSection = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSection);

//add Identity
builder.Services
    .AddIdentity<AppUser, AppRole>(options =>
    {
        options.User.RequireUniqueEmail = true;
        // Password settings
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

string rootPath = builder.Environment.ContentRootPath;
string wwwroot = Path.Combine(rootPath, "wwwroot");
string imagesPath = Path.Combine(wwwroot, "images");

Settings.ImagesPath = imagesPath;
Settings.RootPath = wwwroot;

if (!Directory.Exists(wwwroot))
{
    Directory.CreateDirectory(wwwroot);
}

if (!Directory.Exists(imagesPath))
{
    Directory.CreateDirectory(imagesPath);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(imagesPath),
    RequestPath = "/images"
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
