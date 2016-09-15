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
    class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<ComputadorViewModel, Computador>();
            CreateMap<FuncionarioViewModel, Funcionario>();
            CreateMap<EmpresaViewModel, Empresa>();
            CreateMap<HdViewModel, Hd>();
            CreateMap<MemoriaRAMViewModel, MemoriaRAM>();
            CreateMap<ProcessadorViewModel, Processador>();
            CreateMap<PlacaMaeViewModel, PlacaMae>();
        }
    }
}
