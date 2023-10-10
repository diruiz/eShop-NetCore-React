namespace eShop.Persistence.Repository.Interface;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetById(long id);
    Task<IEnumerable<T>> GetAll();
    Task Add(T entity);
    void Delete(T entity);
    void Update(T entity);
}
