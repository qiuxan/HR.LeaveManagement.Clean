namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    //CRUD operations all entities to have
    Task<List<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}