using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Domain.Entities
{
    public class Empresa
    {
        [Key]
        public virtual int ID { get; set; }

        public virtual string Nome { get; set; }

        public virtual ICollection<Funcionario> Funcionarios { get; set; }

        public virtual ICollection<Computador> Computadores { get; set; }
    }
}
