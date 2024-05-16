namespace MoviesApp.DAL.Repositories.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /*------------------------------------------------------------------------*/
        // Get All
        Task<IEnumerable<TEntity>> GetAllAsync();
        /*------------------------------------------------------------------------*/
        // Get One By Id
        TEntity? GetById(int id);
        /*------------------------------------------------------------------------*/
        // Create One
        void Create(TEntity entity);
        /*------------------------------------------------------------------------*/
        // Update One
        void Update(TEntity entity);
        /*------------------------------------------------------------------------*/
        // Delete One
        void Delete(TEntity entity);
        /*------------------------------------------------------------------------*/
    }
}
