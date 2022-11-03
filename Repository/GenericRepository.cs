using AgainBefore.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AgainBefore.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ItemDbContext _context = null;
        private DbSet<T> table = null;

        public GenericRepository(ItemDbContext context)
        {
            _context = context;
            table= _context.Set<T>();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
           table.Add(obj);
        }

        public void save()
        {
            _context.SaveChanges();
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> query)
        {
            return table.Where(query);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        
        }
    }
}
