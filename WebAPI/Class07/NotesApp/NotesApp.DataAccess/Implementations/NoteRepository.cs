using NotesApp.DataAccess.Data;
using NotesApp.DataAccess.Interfaces;
using NotesApp.Domain.Models;

namespace NotesApp.DataAccess.Implementations;

public class NoteRepository : INoteRepository
{
    public async Task AddAsync(Note entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Note entity)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Note>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Note?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Note>> GetByIds(List<int> ids)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Note entity)
    {
        throw new NotImplementedException();
    }
}
