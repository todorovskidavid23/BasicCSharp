using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Imlementations
{
    internal class EFStatusRepository : IRepository<Status>
    {
        private readonly ToDoAppDbContext _dbContext;

        public EFStatusRepository(ToDoAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Status entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Status> GetAll()
        {
            throw new NotImplementedException();
        }

        public Status GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Status entity)
        {
            throw new NotImplementedException();
        }
    }
}
