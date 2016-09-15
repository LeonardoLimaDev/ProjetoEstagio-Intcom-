using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Application.ViewModels
{
    public class EmpresaViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Nome da Empresa")]
        public string Nome { get; set; }

        public ICollection<FuncionarioViewModel> Funcionarios { get; set; }

        public ICollection<ComputadorViewModel> Computadores { get; set; }
    }
}
