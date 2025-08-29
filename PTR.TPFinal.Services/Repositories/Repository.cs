using Microsoft.EntityFrameworkCore;
using PTR.TPFinal.Domain.Data;

namespace PTR.TPFinal.Services.Repositories
{
    public class Repository<T>(ECommerceApiContext context) : IRepository<T> where T : class
    {
        protected readonly ECommerceApiContext _context = context;
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public IEnumerable<T> GetAll() => [.. _dbSet];

        public T? GetById(int id) => _dbSet.Find(id);

        public T Create(T entity)
        {
            var added = _dbSet.Add(entity).Entity;
            _context.SaveChanges();
            return added;
        }

        public void Update(T entity, int id)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id) ?? throw new Exception($"{typeof(T).Name} con id {id} no existe");
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
