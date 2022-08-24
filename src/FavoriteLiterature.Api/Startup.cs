using System.Text;
using FavoriteLiterature.Api.Entities.Enums;
using FavoriteLiterature.Api.Extensions;
using FavoriteLiterature.Api.Infrastructure;
using FavoriteLiterature.Api.Infrastructure.Interfaces;
using FavoriteLiterature.Api.Options;
using FavoriteLiterature.Api.Policies;
using FluentValidation.AspNetCore;
using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace FavoriteLiterature.Api;

/// <summary>
/// Данный класс настраивает службы и конвейер запросов приложения.
/// </summary>
public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Регистрирует сервисы, которые используются приложением.
    /// </summary>
    /// <param name="services">Объект, который представляет коллекцию сервисов в приложении.</param>
    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection"); // Строка подключения к БД.
        var jwtOptions = _configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>(); // Определение JwtOptions.

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme) // Надстройка аутентификации.
            .AddJwtBearer(options =>
            {
                options.IncludeErrorDetails = true; // Определяет, должны ли ошибки проверки токена возвращены клиенту.
                options.RequireHttpsMetadata = true; // Определяет, требуется ли HTTPS для метаданных.
                options.SaveToken =
                    true; // Определяет, должен ли сохраняться Bearer token после успешной аутентификации.

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, // Валидация на издателя токена.
                    ValidIssuer = jwtOptions.Issuer, // Издатель токена.
                    ValidateAudience = false, // Валидация на потребителя токена.
                    ValidateIssuerSigningKey = true, // Валидация на подписание ключа.
                    IssuerSigningKey =
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtOptions.SecretKey)
                        ), // Ключ, которым должен быть подписан токен.
                    ValidateLifetime = true, // Позволяет контролировать время жизни токена.
                };
            });

        services.AddAuthorization(options =>
        {
            // Настройка политик доступа для роли - Автор.
            options.AddPolicy(nameof(Roles.Author), policy =>
                policy.Requirements.Add(new MinimumRoleRequirement(Roles.Author)));

            // Настройка политик доступа для роли - Критик.
            options.AddPolicy(nameof(Roles.Critic), policy =>
                policy.Requirements.Add(new MinimumRoleRequirement(Roles.Critic)));
        });

        // Добавление службы для настройки callback.
        services.AddProblemDetails(options =>
        {
            options.Map<ArgumentException>(exception => new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = exception.Message,
            });
        });

        // Добавление службы - Swagger.
        services.AddSwaggerGen(options =>
        {
            // Дополнительная информация для генерации документации.
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "FavLit API",
                Description = "FavLit Open API. " +
                              "Сервис для работы с писателями, которые хотят получить начальную аудиторию.",
                Contact = new OpenApiContact
                {
                    Name = "Цыпин Илья Павлович",
                    Email = "tsypin.i.p@mail.ru",
                    Url = new Uri("https://t.me/Dedicated407"),
                },
            });

            // Добавление описания к Swagger о том, как защищен API.
            options.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Пожалуйста, введите в поле слово 'Bearer', за которым следует пробел и JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

            // Добавление глобальной безопасности.
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
            options.IncludeXmlComments(filePath); // Добавление Xml описаний к API.
        });

        services
            .AddMediatR(typeof(Startup)) // Сканирует сборку, и находит в ней все обработчики запросов.
            .AddAutoMapper(typeof(Startup)); // Добавление AutoMapper.

        services
            .AddControllers() // Использование контроллеров без представлений.
            .AddFluentValidation(configuration => // Добавление валидации.
            {
                configuration.RegisterValidatorsFromAssemblyContaining<Startup>();
                configuration.LocalizationEnabled = true;
            });

        services
            .AddDbContext<DataContext>(options => 
                options.UseNpgsql(connectionString)
                ) // Добавление контекста данных в качестве сервиса.
            .AddScoped<IRepository, Repository>() // Для каждого запроса создается свой объект сервиса.
            .Configure<JwtOptions>(_configuration.GetSection(nameof(JwtOptions)).Bind) // Добавление настроек JwtOptions.
            .AddSingleton<IAuthorizationHandler, MinimumRoleRequirementHandler>(); // Singleton-сервис для политики доступа.
    }

    /// <summary>
    /// Метод,предназначенный для подключения компонентов Middleware.
    /// </summary>
    /// <param name="app">Предоставляет механизмы настройки конвейера запросов приложения.</param>
    /// <param name="env">Предоставляет информацию о среде веб-хостинга, в которой запущено приложение.</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Расширение класса ApplicationBuilder для применении миграции БД.
        app.UseMigrationOfDbContext<DataContext>();

        // isDevelopment - Проверяет, имеет ли текущая среда размещения имя Development.
        if (env.IsDevelopment())
        {
            app.UseProblemDetails(); // Для обработки ошибок (более подробно) в ответах HTTP в виде JSON объекта.

            app.UseSwagger(); // Добавляет Middleware - Swagger.
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            }); // Добавляет UI и дополнительную настройку для отображения Swagger на localhost:<port>.
        }
        else
        {
            app.UseStatusCodePages(async context =>
            {
                var response = context.HttpContext.Response; // Ответ сервера
                var path = context.HttpContext.Request.Path; // Путь по которому был отправлен запрос

                response.ContentType = "text/plain; charset=UTF-8";

                switch (response.StatusCode)
                {
                    case 403:
                        await response.WriteAsync($"Путь: {path}. Доступ запрещен.");
                        break;
                    case 404:
                        await response.WriteAsync($"Ресурс: {path}. Не найдено.");
                        break;
                }
            }); // Для обработки ошибок (от 400 до 599) в ответах HTTP.
        }

        // Добавляет соответствие маршрута в конвейер Middleware.
        // Middleware обращается к набору endpoints, определенных в приложении,
        // и выбирает наиболее подходящее на основе запроса.
        app.UseRouting();

        app.UseAuthentication(); // Предоставляет поддержку аутентификации.
        app.UseAuthorization(); // Предоставляет поддержку авторизации.

        // Добавляет выполнение endpoint в конвейер Middleware.
        // Он запускает делегат, связанный с выбранным endpoint.
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers(); // Конфигурация маршрутов. Использует атрибуты, определенные в контроллерах.
        });
    }
}