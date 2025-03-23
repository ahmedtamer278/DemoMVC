

namespace Demo.BLL.Services
{
    public class DepartmentService(IGenericRepository<Department> repository) : IDepartmentService
    {
        private readonly IGenericRepository<Department> _repository = repository;

        public IEnumerable<DepartmentResponse> GetAll()
        {
            var departments = _repository.GetAll();
            // manual mapping

            return departments.Select(department => department.ToResponse());
        }

        public DepartmentDetailsResponse? GetById(int id)
        {
            var department = _repository.GetById(id);
            // manual mapping
            return department is null ? null : department.ToDetails();

        }

        public int Add(DepartmentRequest request)
        {
            var department = request.ToRequest();
            return _repository.Add(department);
        }
        public int Update(DepartmentUpdateRequest updaterequest)
        {
            var department = updaterequest.ToRequestUpdate();
            return _repository.Update(department);
        }

        public bool Delete(int id)
        {
            var department = _repository.GetById(id);
            if (department is null)
                return false;
            return _repository.Delete(department) > 0 ? true : false;
            {

            }
        }

    }
}
