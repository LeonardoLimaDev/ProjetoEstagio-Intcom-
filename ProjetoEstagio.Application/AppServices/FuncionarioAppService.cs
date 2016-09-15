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
    public class FuncionarioAppService : IFuncionarioAppService
    {
        private IFuncionarioService _serviceFuncionario;

        public FuncionarioAppService(IFuncionarioService serviceFuncionario)
        {
            _serviceFuncionario = serviceFuncionario;
        }

        public FuncionarioViewModel GetFuncionarioByIdUsuario(int id)
        {
            return Mapper.Map<FuncionarioViewModel>(_serviceFuncionario.GetFuncionarioByIdUsuario(id));
        }
    }
}
