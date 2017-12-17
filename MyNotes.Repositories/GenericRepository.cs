using MyNotes.EF;
using MyNotes.Models;
using MyNotes.Models.Interfaces;
using MyNotes.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseModel
    {
        private ApplicationDbContext context;
        IDbSet<T> dbSet;

        public BaseRepository(ApplicationDbContext _context)
        {
            context = _context;
            dbSet = context.Set<T>();
        }

        public void Create(T entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public T GetByID(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(T item)
        {
            item.UpdateDate = DateTime.Now;
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
