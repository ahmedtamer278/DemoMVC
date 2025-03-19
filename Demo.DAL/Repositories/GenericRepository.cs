using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Context;

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
    }
}
