using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Application.ViewModels
{
    public class FuncionarioViewModel
    {
        public virtual int ID { get; set; }

        public int IDUsuario { get; set; }

        public int IDEmpresa { get; set; }

        [Display(Name = "Nome do funcionário")]
        public string Nome { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }

        public virtual EmpresaViewModel Empresa { get; set; }
    }
}
