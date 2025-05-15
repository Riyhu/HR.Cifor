using HR.Cifor.WebApi.Entities;

namespace HR.Cifor.WebApi.Databases;

public class DataContext : DbContext
{
    public DbSet<Employee> Employee { get; set; }
}
