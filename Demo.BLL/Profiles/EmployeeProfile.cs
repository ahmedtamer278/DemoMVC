
namespace Demo.BLL.Profiles
{
    internal class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDetailsResponse>()
                .ForMember(d=>d.Department,options=>options.MapFrom(s=>s.Department.Name))
                .ForMember(d=>d.Image,options=>options.MapFrom(s=>s.ImageName));
            CreateMap<Employee, EmployeeResponse>()
                 .ForMember(d => d.Department, options => options.MapFrom(s => s.Department.Name))
                 .ForMember(d => d.Image, options => options.MapFrom(s => s.ImageName));

            CreateMap<EmployeeRequest, Employee>();
            CreateMap<EmployeeUpdateRequest, Employee>();

        }
    }
}
