using Demo.BLL.Services.AttachmentService;
using Demo.DAL.Models.ommon;

namespace Demo.BLL.Services
{
    public class EmployeeService(IUnitOfWork unitOfWork , IMapper mapper , IAttachmentService attachmentService) : IEmployeeService
    {
        //private readonly IGenericRepository<Employee> _unitOfWork.Employees = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly IAttachmentService _attachmentService = attachmentService;

        public IEnumerable<EmployeeResponse> GetAll(string? SearchValue)
        {
            ///var Employees = _unitOfWork.Employees.GetAll();
            /// manual mapping
            ///return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResponse>>(Employees);
            ///var employee = _unitOfWork.Employees.GetAll().Select(e => new EmployeeResponse
            ///{
            ///    Age = e.Age,
            ///    Email = e.Email,
            ///    EmployeeType = e.EmployeeType.ToString(),
            ///    Gender = e.Gender.ToString(),
            ///    Id = e.Id,
            ///    IsActive = e.IsActive,
            ///    Name = e.Name,
            ///    Salary = e.Salary
            ///}) ;
            
            if(string.IsNullOrWhiteSpace(SearchValue))
            return _unitOfWork.Employees.GetAll(e => new EmployeeResponse
            {
                Age = e.Age,
                Email = e.Email,
                EmployeeType = e.EmployeeType.ToString(),
                Gender = e.Gender.ToString(),
                Id = e.Id,
                IsActive = e.IsActive,
                Name = e.Name,
                Salary = e.Salary,
                Department = e.Department.Name ,
                Image = e.ImageName
            },e=>!e.IsDeleted ,
            e=>e.Department);

            return _unitOfWork.Employees.GetAll(e => new EmployeeResponse
            {
                Age = e.Age,
                Email = e.Email,
                EmployeeType = e.EmployeeType.ToString(),
                Gender = e.Gender.ToString(),
                Id = e.Id,
                IsActive = e.IsActive,
                Name = e.Name,
                Salary = e.Salary,
                Department = e.Department.Name
            }, e => !e.IsDeleted && e.Name.ToLower().Contains(SearchValue.ToLower()),
           e => e.Department);
            //return employees;
        }

        public EmployeeDetailsResponse? GetById(int id)
        {
            var Employee = _unitOfWork.Employees.GetById(id);
            // manual mapping
            return Employee is null ? null : _mapper.Map<Employee, EmployeeDetailsResponse>(Employee);

        }

        public int Add(EmployeeRequest request)
        {
            var Employee = _mapper.Map<EmployeeRequest,Employee>(request);
            if (request.Image is not null)
            Employee.ImageName = _attachmentService.UPload(request.Image,"Images");
             _unitOfWork.Employees.Add(Employee);
            return _unitOfWork.SaveChanges();
        }
        public int Update(EmployeeUpdateRequest updaterequest)
        {
            var Employee = _mapper.Map<EmployeeUpdateRequest,Employee>(updaterequest);
            
             _unitOfWork.Employees.Update(Employee);
            return _unitOfWork.SaveChanges();
        }

        public bool Delete(int id)
        {
            var Employee = _unitOfWork.Employees.GetById(id);
            if (Employee is null)
                return false;
            Employee.IsDeleted = true;
            _unitOfWork.Employees.Update(Employee);
            return _unitOfWork.SaveChanges() > 0 ? true : false;

        }
    }
}
