using AutoMapper;
using ProjetoEstagio.Application.AppServices.Interfaces;
using ProjetoEstagio.Application.ViewModels;
using ProjetoEstagio.Domain.Entities;
using ProjetoEstagio.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Application.AppServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private IUsuarioService _serviceUsuario;

        public UsuarioAppService(IUsuarioService serviceUsuario)
        {
            _serviceUsuario = serviceUsuario;
        }


        public UsuarioViewModel Autenticado(UsuarioViewModel usuario)
        {
            Usuario usuarioService = _serviceUsuario.Autenticado(Mapper.Map<Usuario>(usuario));
            if (usuarioService == null)
            {
                return null;
            }
            usuario.ID = usuarioService.ID;
            return usuario;
        }
    }
}
