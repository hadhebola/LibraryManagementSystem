using LibraryManagementSystem.Api.Filters;
using LibraryManagementSystem.Api.Middlewares;
using LibraryManagementSystem.Application;
using LibraryManagementSystem.Application.Common.Interfaces;
using LibraryManagementSystem.Domain.Interfaces.IRepository;
using LibraryManagementSystem.Infrastructure;
using LibraryManagementSystem.Infrastructure.Repository;
using LibraryManagementSystem.Infrastructure.Seeds;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddAuthorization();

builder.Configuration.AddEnvironmentVariables();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Add services to the container.
builder.Services.AddScoped<LanguageFilter>();
builder.Services.AddScoped<CountryFilter>();
// add layer dependency
builder.Services.AddScoped(typeof(DecryptRequestDataFilter<>));
object value = builder.Services.ApplicationServices(builder.Configuration);
builder.Services.InfrastructureServices(builder.Configuration);
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
builder.Services.AddScoped<DbContextOptionsBuilder<LibraryContext>>();

builder.Services.AddControllers(options => options.Filters.Add(new ApiExceptionFilterAttribute()));




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Library Management",
        Description = "Testing",
        Version = "v1"
    });


    s.OperationFilter<SwaggerHeaderFilter>();
    s.AddSecurityDefinition("LanguageCode", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Description = "Language Code format : en for Engilish",
        Name = "LanguageCode",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "LanguageCode"
    });

    s.AddSecurityDefinition("CountryCode", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Description = "Country Code format : 01 for Nigeria",
        Name = "CountryCode",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "CountryCode"
    });

    s.AddSecurityRequirement(new OpenApiSecurityRequirement() {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "LanguageCode"
                    },
                    Scheme = "LanguageCode",
                    Name = "LanguageCode",
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
    });

    s.AddSecurityRequirement(new OpenApiSecurityRequirement() {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "CountryCode"
                    },
                    Scheme = "CountryCode",
                    Name = "CountryCode",
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
    });

});

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LibraryContext>();    
    var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
    if (env.IsDevelopment())
    {
        DbInitializer.Seed(context);
    }  
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<EncryptResponseDataMiddleware>();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
