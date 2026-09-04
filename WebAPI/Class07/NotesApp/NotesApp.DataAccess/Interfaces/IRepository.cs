using NotesApp.Domain.Models;

namespace NotesApp.DataAccess.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<List<T>>GetAll();
    Task<T?> GetById(int id);
    Task<List<T>> GetByIds(List<int> ids);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
