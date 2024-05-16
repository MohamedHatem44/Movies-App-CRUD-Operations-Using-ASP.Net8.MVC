using Microsoft.EntityFrameworkCore;
using MoviesApp.DAL.Data.Context;

namespace MoviesApp.DAL.Repositories.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        /*------------------------------------------------------------------------*/
        protected readonly MoviesContext _context;
        /*------------------------------------------------------------------------*/
        public GenericRepository(MoviesContext context)
        {
            _context = context;
        }
        /*------------------------------------------------------------------------*/
        // Get All
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }
        /*------------------------------------------------------------------------*/
        // Get One By Id
        public  TEntity? GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        /*------------------------------------------------------------------------*/
        // Create One
        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().AddAsync(entity);
        }
        /*------------------------------------------------------------------------*/
        // Update One
        public void Update(TEntity entity)
        {
        }
        /*------------------------------------------------------------------------*/
        // Delete One
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        /*------------------------------------------------------------------------*/
    }
}
