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
    public class HdAppService : IHdAppService
    {
        private IHdService _serviceHd;

        public HdAppService(IHdService serviceHd)
        {
            _serviceHd = serviceHd;
        }

        public HdViewModel Create(HdViewModel entity, int IdComputador)
        {
            entity = Mapper.Map<HdViewModel>(_serviceHd.Create(Mapper.Map<Hd>(entity), IdComputador));
            return entity;
        }

        public void Edit(HdViewModel entity,int IdComputador)
        {
            _serviceHd.Edit(Mapper.Map<Hd>(entity),IdComputador);
        }
    }
}
