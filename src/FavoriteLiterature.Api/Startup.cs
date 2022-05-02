namespace FavoriteLiterature.Api;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    { }
        
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseStatusCodePages();

        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}