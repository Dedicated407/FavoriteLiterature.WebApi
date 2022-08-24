using App.Metrics.Formatters.Prometheus;

namespace FavoriteLiterature.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host
            .CreateDefaultBuilder(args)
            .UseMetricsWebTracking() // Отслеживание клиентов OAuth2 (для метрик).
            .UseMetricsEndpoints(options => // Настройка endpoints для Prometheus метрик.
            {
                options.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
                options.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
                options.EnvironmentInfoEndpointEnabled = false;
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>(); // Установка класса Startup в качестве стартового.
            });
}