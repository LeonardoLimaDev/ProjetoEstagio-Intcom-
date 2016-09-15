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
    public class EmpresaService : IEmpresaService
    {
        private IEmpresaRepository _repositoryEmpresa;

        public EmpresaService(IEmpresaRepository repositoryEmpresa)
        {
            _repositoryEmpresa = repositoryEmpresa;
        }

        public string GetNomeEmpresaById(int id)
        {
            return _repositoryEmpresa.GetById(id).Nome;
        }

        public Empresa GetById(int id)
        {
            return _repositoryEmpresa.GetById(id);
        }
    }
}
