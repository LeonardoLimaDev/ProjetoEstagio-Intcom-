using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Application.ViewModels
{
    public class MemoriaRAMViewModel
    {
        public virtual int ID { get; set; }

        [Display(Name = "Capacidade da Memória RAM (Gb)")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Digite apenas números.")]
        public virtual string Capacidade { get; set; }

        public virtual int IdComputadorUltimo { get; set; }    
    }
}
