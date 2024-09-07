using Assignment.Data.Contexts;
using Assignment.Data.Entities;
using Assignment.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AssignmentDBContext _context;

        public GenericRepository(AssignmentDBContext context)
        {
            _context = context;
        }

        public void Add(T Entity)
        {
            _context.Set<T>().Add(Entity);
        }

        public void Delete(T Entity)
        { _context.Set<T>().Remove(Entity); 
        
        }

        public IEnumerable<T> GetAll()
            =>_context.Set<T>().AsNoTracking().ToList();


        public T GetById(int id)
        => _context.Set<T>().FirstOrDefault(X => X.Id == id);

        public void Update(T Entity)
        { _context.Set<T>().Update(Entity); 
        }

    }
}
