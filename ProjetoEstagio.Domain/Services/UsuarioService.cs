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
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public Usuario Autenticado(Usuario usuario)
        {
            return _repository.Autenticado(usuario);
        }
    }
}
