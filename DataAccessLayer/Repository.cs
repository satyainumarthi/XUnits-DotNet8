using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DatabaseContext _dbContext;
        private DbSet<T> _dbSet;
        public Repository(DatabaseContext dbcontext)
        {
            _dbContext = dbcontext;
            _dbSet=_dbContext.Set<T>();

        }

        public void Add(T item)
        {
            _dbSet.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var requiredObjToDelete = Get(id);
            _dbSet.Remove(requiredObjToDelete);
            _dbContext.SaveChanges();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
            _dbContext.SaveChanges();
        }
    }
}
