using NotesApp.Domain.Enums;
using NotesApp.Domain.Models;
using System.Net;

namespace NotesApp.DataAccess.Interfaces;

public interface INoteRepository : IRepository<Note>
{
    //Task<List<Note>> GetAllBtPriorityAsync(Priority? priority = null);
}
