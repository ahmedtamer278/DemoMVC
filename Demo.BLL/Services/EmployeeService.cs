

using Demo.DAL.Models.ommon;

namespace Demo.BLL.Services
{
    public class EmployeeService(IGenericRepository<Employee> repository , IMapper mapper) : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public IEnumerable<EmployeeResponse> GetAll()
        {
            //var Employees = _repository.GetAll();
            //// manual mapping

            //return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResponse>>(Employees);
            //var employee = _repository.GetAll().Select(e => new EmployeeResponse
            //{
            //    Age = e.Age,
            //    Email = e.Email,
            //    EmployeeType = e.EmployeeType.ToString(),
            //    Gender = e.Gender.ToString(),
            //    Id = e.Id,
            //    IsActive = e.IsActive,
            //    Name = e.Name,
            //    Salary = e.Salary
            //}) ;
            var employees = _repository.GetAll(e => new EmployeeResponse
            {
                Age = e.Age,
                Email = e.Email,
                EmployeeType = e.EmployeeType.ToString(),
                Gender = e.Gender.ToString(),
                Id = e.Id,
                IsActive = e.IsActive,
                Name = e.Name,
                Salary = e.Salary
            });
            return employees;
        }

        public EmployeeDetailsResponse? GetById(int id)
        {
            var Employee = _repository.GetById(id);
            // manual mapping
            return Employee is null ? null : _mapper.Map<Employee, EmployeeDetailsResponse>(Employee);

        }

        public int Add(EmployeeRequest request)
        {
            var Employee = _mapper.Map<EmployeeRequest,Employee>(request);
            return _repository.Add(Employee);
        }
        public int Update(EmployeeUpdateRequest updaterequest)
        {
            var Employee = _mapper.Map<EmployeeUpdateRequest,Employee>(updaterequest);
            
            return _repository.Update(Employee);
        }

        public bool Delete(int id)
        {
            var Employee = _repository.GetById(id);
            if (Employee is null)
                return false;
            Employee.IsDeleted = true;
            return _repository.Update(Employee) > 0 ? true : false;

        }
    }
}
