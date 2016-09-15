using ProjetoEstagio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Application.AppServices.Interfaces
{
    public interface IMemoriaRAMAppService
    {
        MemoriaRAMViewModel Create(MemoriaRAMViewModel entity, int IdComputador);
        void Edit(MemoriaRAMViewModel entity, int IdComputador);
    }
}
