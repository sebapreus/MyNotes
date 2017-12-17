using MyNotes.EF;
using MyNotes.Models.Interfaces;
using MyNotes.Repositories;
using MyNotes.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MyNotes.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private EF.NoteContext db = null;

        public UnitOfWork()
        {
            db = new EF.NoteContext();
        }
        
        // Słownik będzie używany do sprawdzania instancji repozytoriów
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        public IBaseRepository<T> Repository<T>() where T : class, IBaseModel
        {
            // Jeżeli instancja danego repozytorium istnieje - zostanie zwrócona
            if (repositories.Keys.Contains(typeof(T)) == true)
                return repositories[typeof(T)] as IBaseRepository<T>;
            // Jeżeli nie, zostanie utworzona nowa i dodana do słownika
            IBaseRepository<T> repo = new BaseRepository<T>(db);
            repositories.Add(typeof(T), repo);
            return repo;
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    db.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
