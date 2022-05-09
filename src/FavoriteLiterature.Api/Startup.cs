using FavoriteLiterature.Api.Infrastructure;
using FavoriteLiterature.Api.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        
        services
            .AddDbContext<DataContext>(options => options.UseNpgsql(connectionString))
            .AddScoped<IDataContext, DataContext>();
    }
        
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseStatusCodePages();

        app.UseStaticFiles();
        app.UseRouting();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}