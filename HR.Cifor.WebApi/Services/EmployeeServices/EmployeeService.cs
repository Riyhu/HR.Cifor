using HR.Cifor.WebApi.Databases;
using HR.Cifor.WebApi.Entities;
using HR.Cifor.Models;

namespace HR.Cifor.WebApi.Services.EmployeeServices;

public class EmployeeService(DataContext dataContext, IMapper mapper)
{
    public async Task<List<EmployeeModel>> GetAllAsync()
    {
        var entities = await dataContext.Employee.AsNoTracking().ToListAsync();
        return mapper.Map<List<EmployeeModel>>(entities);
    }

    public async Task<EmployeeModel?> GetByIdAsync(string employeeId)
    {
        var entity = await dataContext.Employee.AsNoTracking()
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        if (entity == null) return null;
        return mapper.Map<EmployeeModel>(entity);
    }

    public async Task<List<EmployeeModel>> SearchAsync(string? name, string? department)
    {
        IQueryable<Employee> query = dataContext.Employee.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(e => e.Name.Contains(name));

        if (!string.IsNullOrWhiteSpace(department))
            query = query.Where(e => e.Department.Contains(department));

        var entities = await query.ToListAsync();
        return mapper.Map<List<EmployeeModel>>(entities);
    }

    public async Task<EmployeeModel> AddAsync(EmployeeModel employeeModel)
    {
        var entity = mapper.Map<Employee>(employeeModel);
        dataContext.Employee.Add(entity);
        await dataContext.SaveChangesAsync();
        return mapper.Map<EmployeeModel>(entity);
    }

    public async Task<bool> UpdateAsync(string employeeId, EmployeeModel updatedModel)
    {
        var existing = await dataContext.Employee.FindAsync(employeeId);
        if (existing == null) return false;

        mapper.Map(updatedModel, existing);
        await dataContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string employeeId)
    {
        var existing = await dataContext.Employee
            .Where(e => e.EmployeeId.ToString() == employeeId)
            .FirstOrDefaultAsync();

        if (existing == null) return false;

        dataContext.Employee.Remove(existing);
        await dataContext.SaveChangesAsync();
        return true;
    }

}
