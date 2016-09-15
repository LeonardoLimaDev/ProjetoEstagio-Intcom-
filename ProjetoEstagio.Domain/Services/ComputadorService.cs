using ProjetoEstagio.Domain.Entities;
using ProjetoEstagio.Domain.Interfaces.Generic;
using ProjetoEstagio.Domain.Interfaces.Repository;
using ProjetoEstagio.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Domain.Services
{
    public class ComputadorService : IComputadorService
    {
        private IComputadorRepository _repositoryComputador;
        private IProcessadorRepository _repositoryProcessador;
        private IPlacaMaeRepository _repositoryPlacaMae;

        public ComputadorService(IComputadorRepository repositoryComputador,
                                IProcessadorRepository repositoryProcessador,
                                IPlacaMaeRepository repositoryPlacaMae)
        {
            _repositoryComputador = repositoryComputador;
            _repositoryPlacaMae = repositoryPlacaMae;
            _repositoryProcessador = repositoryProcessador;
        }

        public Computador Create(Computador entity,int IdEmpresa)
        {
            entity.IDEmpresa = IdEmpresa;
            _repositoryComputador.Create(entity);
            _repositoryComputador.SaveChanges();
            return entity;

        }

        public List<Computador> GetComputadoresByIdEmpresa(int id)
        {
            return _repositoryComputador.GetList(x => x.Empresa.ID == id);
        }


        public Computador GetById(int id)
        {
            return _repositoryComputador.GetById(id);
        }

        public void DeleteById(int id)
        {
            _repositoryComputador.DeleteById(id);
            _repositoryComputador.SaveChanges();
        }

        public void Edit(Computador entity, int IdEmpresa)
        {
            entity.IDEmpresa = IdEmpresa;
            _repositoryComputador.Update(entity);
            //_repositoryComputador.SaveChanges();           
        }
    }
}
