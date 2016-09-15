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
    public class ComputadorAppService : IComputadorAppService
    {
        private IComputadorService _serviceComputador;

        public ComputadorAppService(IComputadorService serviceComputador)
        {
            _serviceComputador = serviceComputador;
        }

        public ComputadorViewModel Create(ComputadorViewModel computador,int IdEmpresa)
        {
            computador = Mapper.Map<ComputadorViewModel>(_serviceComputador.Create(Mapper.Map<Computador>(computador),IdEmpresa));
            return computador;
        }

        public List<ComputadorViewModel> GetComputadoresByIdEmpresa(int id)
        {
            return Mapper.Map<List<ComputadorViewModel>>(_serviceComputador.GetComputadoresByIdEmpresa(id));
        }

        public ComputadorViewModel GetById(int id)
        {
            Computador computador = _serviceComputador.GetById(id);
            ComputadorViewModel computadorViewModel = Mapper.Map<ComputadorViewModel>(computador);
            computadorViewModel.IdEmpresaEdit = computador.IDEmpresa;
            return computadorViewModel;
        }


        public void DeleteById(int id)
        {
            _serviceComputador.DeleteById(id);
        }


        public void Edit(ComputadorViewModel computador, int IdEmpresa)
        {
            Computador entity = Mapper.Map<Computador>(computador);
            entity.IDPlacaMae = computador.PlacaMae.ID;
            entity.IDProcessador = computador.Processador.ID;
            _serviceComputador.Edit(entity, IdEmpresa);
        }
    }
}
