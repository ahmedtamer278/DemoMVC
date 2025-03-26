
namespace Demo.DAL.Repositories
{
    public interface IGenericRepository <TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll(bool withTracking = false);
        IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity,TResult>>selector,Expression<Func<TEntity , bool>> predicate,params Expression<Func<TEntity , BaseEntity>>[] includes);
       
        
        //IQueryable<TEntity> GetAllQueryable();


        TEntity? GetById(int id);
        void Update(TEntity entity);
    }
}
