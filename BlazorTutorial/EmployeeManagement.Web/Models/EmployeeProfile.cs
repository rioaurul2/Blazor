using AutoMapper;
using EmployeeManagementModels;

namespace EmployeeManagement.Web.Models
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() { 
            CreateMap<Employee, EditEmployeeModel>()
                .ForMember(dest => dest.ConfirmEmail,
                            option => option.MapFrom(source => source.Email));
            CreateMap<EditEmployeeModel, Employee>();
        }
    }
}
