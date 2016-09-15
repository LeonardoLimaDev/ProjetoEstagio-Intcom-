using ProjetoEstagio.Domain.Entities;
using ProjetoEstagio.Domain.Interfaces.Repository;
using ProjetoEstagio.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Domain.Services
{
    public class HdService : IHdService
    {
        private IHdRepository _repositoryHd;

        public HdService(IHdRepository repositoryHd)
        {
            _repositoryHd = repositoryHd;
        }

        public Hd Create(Hd entity, int IdComputador)
        {
            entity.IDComputador = IdComputador;
            _repositoryHd.Create(entity);
            _repositoryHd.SaveChanges();
            return entity;
        }

        public void Edit(Hd entity, int IdComputador)
        {
            entity.IDComputador = IdComputador;
            _repositoryHd.Edit(entity);
            _repositoryHd.SaveChanges();
        }
    }
}
