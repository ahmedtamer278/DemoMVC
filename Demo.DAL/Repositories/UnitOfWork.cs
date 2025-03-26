namespace Demo.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _employeeRepository = new Lazy<IEmployeeRepository>(()=>new EmployeeRepository(context));
            _departmentRepository = new Lazy<IDepartmentRepository>(()=>new DepartmentRepository(context));
        }

        public IEmployeeRepository Employees => _employeeRepository.Value;

        public IDepartmentRepository Departments => _departmentRepository.Value;

        public int SaveChanges()=> _context.SaveChanges();
        
    }
}
