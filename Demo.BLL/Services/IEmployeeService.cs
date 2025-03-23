
namespace Demo.BLL.Services
{
    public interface IEmployeeService
    {
        int Add(EmployeeRequest request);
        bool Delete(int id);
        IEnumerable<EmployeeResponse> GetAll();
        EmployeeDetailsResponse? GetById(int id);
        int Update(EmployeeUpdateRequest updaterequest);
    }
}
