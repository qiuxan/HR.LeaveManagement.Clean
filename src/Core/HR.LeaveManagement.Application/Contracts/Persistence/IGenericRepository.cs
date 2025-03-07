using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    //CRUD operations all entities to have
    Task<IReadOnlyList<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}