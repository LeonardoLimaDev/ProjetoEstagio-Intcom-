using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Domain.Entities
{
    public class Processador
    {
        [Key]
        public virtual int ID { get; set; }

        public virtual string Modelo { get; set; }

        public virtual string Marca { get; set; }

        public virtual string Velocidade { get; set; }
    }
}
