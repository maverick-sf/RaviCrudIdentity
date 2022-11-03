using System.Linq.Expressions;

namespace AgainBefore.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void save();
        IQueryable<T> Search(Expression<Func<T, bool>>query);
        
    }
}
