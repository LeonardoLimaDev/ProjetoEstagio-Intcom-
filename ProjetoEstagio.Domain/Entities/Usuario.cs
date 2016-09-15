using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Domain.Entities
{
    public class Usuario
    {
        
        public virtual int ID { get; set; }

        public virtual string Login { get; set; }

        public virtual string Senha { get; set; }

    }
}
