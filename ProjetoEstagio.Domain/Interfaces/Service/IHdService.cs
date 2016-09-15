using ProjetoEstagio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Domain.Interfaces.Service
{
    public interface IHdService
    {
        Hd Create(Hd entity, int IdComputador);
        void Edit(Hd entity, int IdComputador);
    }
}
