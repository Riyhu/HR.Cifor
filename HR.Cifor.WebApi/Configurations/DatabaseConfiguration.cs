using HR.Cifor.WebApi.Databases;

namespace HR.Cifor.WebApi.Configurations;

public static class DatabaseConfiguration
{
    public static void ConfigureDatabase(this WebApplication app)
    {
        var serviceProvider = app.Services.CreateScope().ServiceProvider;
        var dataContext = serviceProvider.GetRequiredService<DataContext>();
        dataContext.Database.Migrate();

        DataInitializer.Run(serviceProvider);

    }
}
