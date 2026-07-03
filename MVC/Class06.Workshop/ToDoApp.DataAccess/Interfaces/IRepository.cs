using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Interfaces
{
    //CRUD methods for the repository pattern (for accessing the db)
    public interface IRepository<T> where T : BaseEntity
    {
        //CRUD
        List<T> GetAll(); //Read all
        T GetById(int id); //Read by Id
        void Create(T entity); // Create
        void Update(T entity); // Upadate
        void Delete(int id); //Delete by Id
    }
}
