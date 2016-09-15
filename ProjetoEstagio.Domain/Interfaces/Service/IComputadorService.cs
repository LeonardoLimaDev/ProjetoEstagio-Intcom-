using ProjetoEstagio.Domain.Entities;
using ProjetoEstagio.Domain.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Domain.Interfaces.Service
{
    public interface IComputadorService
    {
        List<Computador> GetComputadoresByIdEmpresa(int id);
        Computador Create(Computador entity, int IdEmpresa);
        Computador GetById(int id);
        void DeleteById(int id);
        void Edit(Computador computador, int IdEmpresa);
    }
}
