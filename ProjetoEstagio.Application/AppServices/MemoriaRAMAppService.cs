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
    public class MemoriaRAMAppService : IMemoriaRAMAppService
    {
        private IMemoriaRAMService _serviceMemoriaRAM;

        public MemoriaRAMAppService(IMemoriaRAMService serviceMemoriaRAM)
        {
            _serviceMemoriaRAM = serviceMemoriaRAM;
        }

        public MemoriaRAMViewModel Create(MemoriaRAMViewModel entity, int IdComputador)
        {
            entity = Mapper.Map<MemoriaRAMViewModel>(_serviceMemoriaRAM.Create(Mapper.Map<MemoriaRAM>(entity), IdComputador));
            return entity;
        }

        public void Edit(MemoriaRAMViewModel entity, int IdComputador)
        {
            _serviceMemoriaRAM.Edit(Mapper.Map<MemoriaRAM>(entity),IdComputador);
        }
    }
}
