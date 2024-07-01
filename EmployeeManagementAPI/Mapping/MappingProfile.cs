using AutoMapper;
using EmployeeManagementApi.DTO;
using EmployeeManagementApi.Commands;
using EmployeeManagementApi.Models.Entities;

namespace EmployeeManagementApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<CreateEmployeeCommand, Employee>();
            CreateMap<UpdateEmployeeCommand, Employee>();
        }
    }
}