

namespace Demo.DAL.Repositories
{
    public class GenericRepository<TEntity>(ApplicationDbContext context) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _context = context;

        public TEntity? GetById(int id) => _context.Set<TEntity>().Find(id);

        public IEnumerable<TEntity> GetAll(bool withTracking = false) => withTracking ? _context.Set<TEntity>().Where(d => !d.IsDeleted).ToList() : _context.Set<TEntity>().AsNoTracking().Where(d => !d.IsDeleted).ToList();

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        //public IQueryable<TEntity> GetAllQueryable()
        //{
        //     return _context.Set<TEntity>().AsNoTracking().Where(d => !d.IsDeleted);
        //}

        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, BaseEntity>>[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            foreach (var include in includes)
                query.Include(include);
           return query.AsNoTracking()
                .Where(predicate)
                .Select(selector)
                .ToList();
        }

       
    }
}
