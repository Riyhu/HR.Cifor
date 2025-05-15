using HR.Cifor.WebApi.Entities;

namespace HR.Cifor.WebApi.Databases;

public static class DataInitializer
{
    public static void Run(IServiceProvider services)
    {
        var dataContext = services.GetRequiredService<DataContext>();
        if (dataContext.Set<Employee>().Any()) return;
        var employees = new[]
          {
                new Employee { EmployeeId = "G0001", Name = "John Doe", Address = "Jl. Bogor Raya", Department = "HR", Email = "John.doe@gmail.com" },
                new Employee { EmployeeId = "G0002", Name = "Sally Kun", Address = "Kemang Raya", Department = "HR", Email = "Sally.kun@gmail.com" },
                new Employee { EmployeeId = "G0003", Name = "Hiro Katajima", Address = "Pluit, Jakarta", Department = "ICT", Email = "Hiro.Katajima@gmail.com" },
                new Employee { EmployeeId = "G0004", Name = "Gareth Kelly", Address = "Bandung", Department = "ICT", Email = "Gareth.kelly@gmail.com" },
                new Employee { EmployeeId = "G0005", Name = "Rose Yang", Address = "Depok", Department = "IS", Email = "Rose.yang@gmail.com" }
            };

        dataContext.Set<Employee>().AddRange(employees);
        dataContext.SaveChanges();
    }
}
