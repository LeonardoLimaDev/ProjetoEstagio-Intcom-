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
    public class FuncionarioService : IFuncionarioService
    {
        private IFuncionarioRepository _repository;

        public FuncionarioService(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public Funcionario GetFuncionarioByIdUsuario(int id)
        {
            return _repository.Get(x => x.IDUsuario == id);
        }
    }
}
