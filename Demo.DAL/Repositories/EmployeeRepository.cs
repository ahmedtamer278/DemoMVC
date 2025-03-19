
using Demo.DAL.Data.Context;

namespace Demo.DAL.Repositories
{
    public class EmployeeRepository(ApplicationDbContext context) : GenericRepository<Employee>(context),IEmployeeRepository
    {
       
    }
}
