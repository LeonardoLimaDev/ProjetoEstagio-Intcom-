using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Application.ViewModels
{
    public class PlacaMaeViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Modelo da Placa Mãe")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Modelo { get; set; }

        [Display(Name = "Marca da Placa Mãe")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Marca { get; set; }
    }
}
