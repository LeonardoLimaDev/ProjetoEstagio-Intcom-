using ProjetoEstagio.Infra.Data.Infrastructure;
using ProjetoEstagio.Domain.Entities;
using ProjetoEstagio.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoEstagio.Infra.Data.Context;
using System.Data.Entity;

namespace ProjetoEstagio.Infra.Data.Repositories
{
    public class ComputadorRepository : GenericRepository<Computador> , IComputadorRepository
    {

        protected ProjetoEstagioContext _entities;
        protected IDbSet<Computador> _dbSet;


        public ComputadorRepository(ProjetoEstagioContext context)
            :base(context)
        {
            _entities = context;
            _dbSet = _entities.Set<Computador>();
        }

        public void Update(Computador obj)
        {
            var entry = _dbSet.Find(obj.ID);
            if (entry != null)
            {
                _entities.Entry(entry).CurrentValues.SetValues(obj);
                _entities.SaveChanges();
            }
        }
    }
}
