using ProjetoEstagio.Infra.Data.Context;
using ProjetoEstagio.Domain.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Infra.Data.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbContext _entities;
        protected IDbSet<T> _dbSet;

        public GenericRepository()
        {
            DbContext context = new ProjetoEstagioContext();
            _entities = context;
            _dbSet = _entities.Set<T>();
        }

        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbSet = _entities.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable<T>();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T Get(Func<T,bool> preticate)
        {
            T entity = null;
            IQueryable<T> query;

            query = _entities.Set<T>();

            entity = query.Where(preticate).AsEnumerable().FirstOrDefault();

            return entity;
        }

        public List<T> GetList(Func<T, bool> preticate)
        {
            List<T> list = null;
            IQueryable<T> query;

            query = _entities.Set<T>();

            list = query.Where(preticate).ToList();

            return list;
        }

        public T Create(T entity)
        {
            return _dbSet.Add(entity);
        }

        public void DeleteById(int id)
        {
            var entity = _entities.Set<T>().Find(id);
            _dbSet.Remove(entity);
        }

        public void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;

        }

        public void SaveChanges()
        {
            _entities.SaveChanges();
        }
    }
}
