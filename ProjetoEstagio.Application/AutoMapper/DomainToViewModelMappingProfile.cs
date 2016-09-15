using AutoMapper;
using ProjetoEstagio.Application.ViewModels;
using ProjetoEstagio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Application.AutoMapper
{
    class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Computador, ComputadorViewModel>();
            CreateMap<Funcionario, FuncionarioViewModel>();
            CreateMap<Empresa, EmpresaViewModel>();
            CreateMap<Hd, HdViewModel>();
            CreateMap<MemoriaRAM, MemoriaRAMViewModel>();
            CreateMap<Processador, ProcessadorViewModel>();
            CreateMap<PlacaMae, PlacaMaeViewModel>();
        }
    }
}
