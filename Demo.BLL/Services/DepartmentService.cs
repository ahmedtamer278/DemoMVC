using Demo.BLL.DataTransferObject.Departments;

namespace Demo.BLL.Services
{
    public class DepartmentService(IUnitOfWork unitOfWork) : IDepartmentService
    {
        //private readonly IGenericRepository<Department> _unitOfWork.Departments = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public IEnumerable<DepartmentResponse> GetAll()
        {
            var departments = _unitOfWork.Departments.GetAll();
            // manual mapping

            return departments.Select(department => department.ToResponse());
        }

        public DepartmentDetailsResponse? GetById(int id)
        {
            var department = _unitOfWork.Departments.GetById(id);
            // manual mapping
            return department is null ? null : department.ToDetails();

        }

        public int Add(DepartmentRequest request)
        {
            var department = request.ToRequest();
             _unitOfWork.Departments.Add(department);
            return _unitOfWork.SaveChanges();
        }
        public int Update(DepartmentUpdateRequest updaterequest)
        {
            var department = updaterequest.ToRequestUpdate();
             _unitOfWork.Departments.Update(department);
            return _unitOfWork.SaveChanges();
        }

        public bool Delete(int id)
        {
            var department = _unitOfWork.Departments.GetById(id);
            if (department is null)
                return false;
            _unitOfWork.Departments.Delete(department);
            return _unitOfWork.SaveChanges()  > 0 ? true : false;
            
        }

    }
}
