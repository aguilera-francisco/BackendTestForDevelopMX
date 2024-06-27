namespace BackendTest.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> Get();

        Task<TEntity> GetById(int id);


    }
}
