using AutoMapper;
using HR.Cifor.Models;
using HR.Cifor.WebApi.Entities;

namespace HR.Cifor.WebApi.Services.EmployeeServices;

public class EmployeeMapper : Profile
{
    public EmployeeMapper()
    {
        CreateMap<Employee, EmployeeModel>().ReverseMap();
    }
}
