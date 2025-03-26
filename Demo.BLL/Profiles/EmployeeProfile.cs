
namespace Demo.BLL.Profiles
{
    internal class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDetailsResponse>()
                .ForMember(d=>d.Department,options=>options.MapFrom(s=>s.Department.Name));
            CreateMap<Employee, EmployeeResponse>()
                 .ForMember(d => d.Department, options => options.MapFrom(s => s.Department.Name));

            CreateMap<EmployeeRequest, Employee>();
            CreateMap<EmployeeUpdateRequest, Employee>();

        }
    }
}
