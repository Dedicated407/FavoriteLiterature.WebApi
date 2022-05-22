using System.Text;
using FavoriteLiterature.Api.Infrastructure;
using FavoriteLiterature.Api.Infrastructure.Interfaces;
using FavoriteLiterature.Api.Options;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace FavoriteLiterature.Api;

public class Startup
{
    private readonly IConfiguration _configuration;
    
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        var jwtOptions = _configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.IncludeErrorDetails = true;
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.Issuer,
                    
                    ValidateAudience = false,
                    
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
                    
                    ValidateLifetime = false,
                };
            });

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "FavLit API", 
                Description = "FavLit Open API. " +
                              "A service for working with beginners writers who want to get an initial audience.",
                Contact = new OpenApiContact
                {
                    Name = "Tsypin I.P.",
                    Email = "tsypin.i.p@mail.ru",
                    Url = new Uri("https://t.me/Dedicated407"),
                },
            });
            
            options.AddSecurityDefinition("Bearer", 
                new OpenApiSecurityScheme { 
                    In = ParameterLocation.Header,
                    Description = "Please enter into field the word 'Bearer' following by space and JWT", 
                    Name = "Authorization", 
                    Type = SecuritySchemeType.ApiKey
                });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement 
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme,
                        }
                    },
                    new string[] { }
                }
            });

            var filePath = Path.Combine(AppContext.BaseDirectory, "FavoriteLiterature.Api.xml");
            options.IncludeXmlComments(filePath);
        });

        services.AddMediatR(typeof(Startup));
        services.AddControllers();
        
        services
            .AddDbContext<DataContext>(options => options.UseNpgsql(connectionString))
            .AddScoped<IRepository, DataContext>()
            .Configure<JwtOptions>(_configuration.GetSection(nameof(JwtOptions)).Bind);
    }
        
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseExceptionHandler("/api/error");
        }
        
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseStatusCodePages();
        
        app.UseRouting();
        
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapSwagger();
        });
    }
}