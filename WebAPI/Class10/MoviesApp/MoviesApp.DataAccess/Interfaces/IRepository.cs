using MoviesApp.Domain.Models;

namespace MoviesApp.DataAccess.Interfaces
{
    // Операциите што ги има СЕКОЈ ентитет.
    // Ограничувањето where T : BaseEntity ни гарантира дека T има Id.
    public interface IRepository<T> where T : BaseEntity
    {
        //Task means that the method is asynchronous and will return a Task object that represents the ongoing operation.
        //The Task object can be awaited, allowing the calling code to continue executing while the operation is being performed in the background.
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetByIdsAsync(List<int> ids);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
