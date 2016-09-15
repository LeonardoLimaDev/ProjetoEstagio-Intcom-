using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public int ID;

        [Required(ErrorMessage = "O campo login é obrigatório.")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Digite apenas letras e números.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        [MinLength(8, ErrorMessage = "Sua senha precisa ter no mínimo 8 caracteres.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
