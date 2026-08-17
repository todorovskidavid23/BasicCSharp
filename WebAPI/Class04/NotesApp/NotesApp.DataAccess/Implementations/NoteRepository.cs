using NotesApp.DataAccess.Data;
using NotesApp.DataAccess.Interfaces;
using NotesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.DataAccess.Implementations
{
    public class NoteRepository : INoteRepository
    {
        public void Add(Note entity)
        {
            entity.Id = StaticDb.NextNoteId();
            StaticDb.Notes.Add(entity);
        }

        public void Delete(Note entity)
        {
            StaticDb.Notes.Remove(entity);
        }

        public List<Note> GetAll()
        {
            return StaticDb.Notes;

        }

        public Note? GetById(int id)
        {
            return StaticDb.Notes.FirstOrDefault(note => note.Id == id);
        }

        public void Update(Note entity)
        {
            int index = StaticDb.Notes.FindIndex(note=>note.Id==entity.Id);
            if (index >= 0)
            {
                StaticDb.Notes[index] = entity;
            }
        }
    }
}
