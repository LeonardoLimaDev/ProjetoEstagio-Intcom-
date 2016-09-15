using ProjetoEstagio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Domain.Interfaces.Service
{
    public interface IMemoriaRAMService
    {
        MemoriaRAM Create(MemoriaRAM entity, int IdComputador);
        void Edit(MemoriaRAM entity, int IdComputador);
    }
}
