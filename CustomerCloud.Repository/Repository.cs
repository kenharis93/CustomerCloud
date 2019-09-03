using CustomerCloud.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCloud.Repository
{
    public class Repository<T> where T : class, IEntity
    {
        private CustomerContext _context;

        public Repository()
        {
            _context = new CustomerContext();
        }

        public void Create(T item)
        {
            _context.Entry<T>(item).State = EntityState.Added;
            _context.SaveChanges();
        }

        public T Read(Guid id)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            return dbQuery.FirstOrDefault(i => i.Id == id);
        }

        public void Update(T item)
        {
            T existing = _context.Set<T>().FirstOrDefault(entry => entry.Id == item.Id);
            if (existing != null)
            {
                _context.Entry(existing).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            _context.Entry(item).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            T item = Read(id);
            _context.Entry(item).State = EntityState.Deleted;
            _context.SaveChanges();
        }

    }
}
