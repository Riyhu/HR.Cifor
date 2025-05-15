
namespace HR.Cifor.WebApi.Databases;

public class SqliteDataContext(IConfiguration configuration) : DataContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(configuration.GetConnectionString("Sqlite"));
    }

}
