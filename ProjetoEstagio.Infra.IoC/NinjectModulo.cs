using Ninject.Modules;
using ProjetoEstagio.Application.AppServices;
using ProjetoEstagio.Application.AppServices.Interfaces;
using ProjetoEstagio.Domain.Interfaces.Repository;
using ProjetoEstagio.Domain.Interfaces.Service;
using ProjetoEstagio.Domain.Services;
using ProjetoEstagio.Infra.Data.Context;
using ProjetoEstagio.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Infra.IoC
{
    class NinjectModulo : NinjectModule
    {
        public override void Load()
        {
            //REPOSITORIES
            Bind<IComputadorRepository>().To<ComputadorRepository>();
            Bind<IUsuarioRepository>().To<UsuarioRepository>();
            Bind<IFuncionarioRepository>().To<FuncionarioRepository>();
            Bind<IEmpresaRepository>().To<EmpresaRepository>();
            Bind<IMemoriaRAMRepository>().To<MemoriaRAMRepository>();
            Bind<IHdRepository>().To<HdRepository>();
            Bind<IProcessadorRepository>().To<ProcessadorRepository>();
            Bind<IPlacaMaeRepository>().To<PlacaMaeRepository>();

            //SERVICES
            Bind<IComputadorService>().To<ComputadorService>();
            Bind<IUsuarioService>().To<UsuarioService>();
            Bind<IFuncionarioService>().To<FuncionarioService>();
            Bind<IEmpresaService>().To<EmpresaService>();
            Bind<IMemoriaRAMService>().To<MemoriaRAMService>();
            Bind<IHdService>().To<HdService>();
            
            //APPSERVICE
            Bind<IComputadorAppService>().To<ComputadorAppService>();
            Bind<IUsuarioAppService>().To<UsuarioAppService>();
            Bind<IFuncionarioAppService>().To<FuncionarioAppService>();
            Bind<IEmpresaAppService>().To<EmpresaAppService>();
            Bind<IMemoriaRAMAppService>().To<MemoriaRAMAppService>();
            Bind<IHdAppService>().To<HdAppService>();

            Bind<ProjetoEstagioContext>().ToSelf().InSingletonScope();
        }
    }
}
