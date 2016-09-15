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
    public class EmpresaAppService : IEmpresaAppService
    {
        private IEmpresaService _serviceEmpresa;

        public EmpresaAppService(IEmpresaService serviceEmpresa)
        {
            _serviceEmpresa = serviceEmpresa;
        }

        public string GetNomeEmpresaById(int id)
        {
             return _serviceEmpresa.GetNomeEmpresaById(id);
        }

        public EmpresaViewModel GetById(int id)
        {
            return Mapper.Map<EmpresaViewModel>(_serviceEmpresa.GetById(id));
        }
    }
}
