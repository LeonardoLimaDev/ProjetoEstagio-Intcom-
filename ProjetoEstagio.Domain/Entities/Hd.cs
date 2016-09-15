using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Domain.Entities
{
    public class Hd
    {
        [Key]
        public virtual int ID { get; set; }

        [Column("IDComputador")]
        public virtual int IDComputador { get; set; }

        public virtual string Capacidade { get; set; }

        [ForeignKey("IDComputador")]
        public virtual Computador Computador { get; set; }
    }
}
