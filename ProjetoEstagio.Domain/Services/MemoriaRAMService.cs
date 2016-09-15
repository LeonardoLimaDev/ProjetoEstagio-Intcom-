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
    public class MemoriaRAMService : IMemoriaRAMService
    {
        private IMemoriaRAMRepository _repositoryMemoriaRAM;

        public MemoriaRAMService(IMemoriaRAMRepository repositoryMemoriaRAM)
        {
            _repositoryMemoriaRAM = repositoryMemoriaRAM;
        }

        public MemoriaRAM Create(MemoriaRAM entity, int IdComputador)
        {
            entity.IDComputador = IdComputador;
            _repositoryMemoriaRAM.Create(entity);
            _repositoryMemoriaRAM.SaveChanges();
            return entity;
        }

        public void Edit(MemoriaRAM entity, int IdComputador)
        {
            entity.IDComputador = IdComputador;
            _repositoryMemoriaRAM.Edit(entity);
            _repositoryMemoriaRAM.SaveChanges();
        }
    }
}
