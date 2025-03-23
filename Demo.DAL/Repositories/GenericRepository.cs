

namespace Demo.DAL.Repositories
{
    public class GenericRepository<TEntity>(ApplicationDbContext context) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _context = context;

        public TEntity? GetById(int id) => _context.Set<TEntity>().Find(id);

        public IEnumerable<TEntity> GetAll(bool withTracking = false) => withTracking ? _context.Set<TEntity>().Where(d => !d.IsDeleted).ToList() : _context.Set<TEntity>().AsNoTracking().Where(d => !d.IsDeleted).ToList();

        public int Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges();
        }
        public int Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return _context.SaveChanges();
        }
        public int Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges();
        }

        //public IQueryable<TEntity> GetAllQueryable()
        //{
        //     return _context.Set<TEntity>().AsNoTracking().Where(d => !d.IsDeleted);
        //}

        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return _context.Set<TEntity>().AsNoTracking().Where(d => !d.IsDeleted).Select(selector)
                .ToList();
        }
    }
}
