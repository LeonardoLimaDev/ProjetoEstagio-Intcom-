using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Application.ViewModels
{
    public class ProcessadorViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Modelo do Processador")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Modelo { get; set; }

        [Display(Name = "Marca do Processador")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Marca { get; set; }

        [Display(Name = "Velocidade do Processador")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Velocidade { get; set; }
    }
}
