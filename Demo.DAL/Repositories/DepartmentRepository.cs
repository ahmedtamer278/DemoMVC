using Demo.DAL.Data.Context;

namespace Demo.DAL.Repositories
{
    public class DepartmentRepository(ApplicationDbContext context) : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context = context;

        public Department? GetById(int id) => _context.Departments.Find(id);

        public IEnumerable<Department> GetAll(bool withTracking = false) => withTracking ? _context.Departments.Where(d => !d.IsDeleted).ToList() : _context.Departments.AsNoTracking().Where(d => !d.IsDeleted).ToList();

        public int Add(Department department)
        {
            _context.Departments.Add(department);
            return _context.SaveChanges();
        }
        public int Update(Department department)
        {
            _context.Departments.Update(department);
            return _context.SaveChanges();
        }
        public int Delete(Department department)
        {
            _context.Departments.Remove(department);
            return _context.SaveChanges();
        }


    }
}
