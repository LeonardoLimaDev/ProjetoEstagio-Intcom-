using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Application.ViewModels
{
    public class HdViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Capacidade de Armazenamento do Hd (Gb)")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Digite apenas números.")]
        public string Capacidade { get; set; }

        public virtual int IdComputadorUltimo { get; set; }
    } 
    
}
