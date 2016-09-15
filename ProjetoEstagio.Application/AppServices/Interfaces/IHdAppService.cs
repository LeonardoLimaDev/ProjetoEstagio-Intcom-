using ProjetoEstagio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Application.AppServices.Interfaces
{
    public interface IHdAppService
    {
        HdViewModel Create(HdViewModel entity, int IdComputador);
        void Edit(HdViewModel entity, int IdComputador);
    }
}
