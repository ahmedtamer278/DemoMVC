
namespace Demo.BLL.Services
{
    public interface IEmployeeService
    {
        int Add(EmployeeRequest request);
        bool Delete(int id);
        IEnumerable<EmployeeResponse> GetAll(string? SearchValue);
        EmployeeDetailsResponse? GetById(int id);
        int Update(EmployeeUpdateRequest updaterequest);
    }
}
