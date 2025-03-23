
namespace Demo.BLL.Services
{
    public interface IDepartmentService
    {
        int Add(DepartmentRequest request);
        bool Delete(int id);
        IEnumerable<DepartmentResponse> GetAll();
        DepartmentDetailsResponse? GetById(int id);
        int Update(DepartmentUpdateRequest updaterequest);
    }
}