
namespace Demo.BLL.Profiles
{
    internal class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDetailsResponse>();
            CreateMap<Employee, EmployeeResponse>();

            CreateMap<EmployeeRequest, Employee>();
            CreateMap<EmployeeUpdateRequest, Employee>();

        }
    }
}
