namespace HR.Cifor.WebApi.Entities;

public class Employee : BaseEntity
{
    public string EmployeeId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
}
