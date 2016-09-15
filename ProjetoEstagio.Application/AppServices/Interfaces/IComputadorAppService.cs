using ProjetoEstagio.Application.ViewModels;
using ProjetoEstagio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Application.AppServices.Interfaces
{
    public interface IComputadorAppService
    {
        List<ComputadorViewModel> GetComputadoresByIdEmpresa(int id);
        ComputadorViewModel Create(ComputadorViewModel computador, int IdEmpresa);
        ComputadorViewModel GetById(int id);
        void DeleteById(int id);
        void Edit(ComputadorViewModel computador, int IdEmpresa);
    }
}
