using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Domain.Entities
{
    public class Computador
    {
        [Key]
        public virtual int ID { get; set; }

        [Column("IDEmpresa")]
        public int IDEmpresa { get; set; }

        [Column("IDPlacaMae")]
        public int IDPlacaMae { get; set; }

        [Column("IDProcessador")]
        public int IDProcessador { get; set; }

        [ForeignKey("IDEmpresa")]
        public virtual Empresa Empresa { get; set; }

        [ForeignKey("IDPlacaMae")]
        public virtual PlacaMae PlacaMae { get; set; }

        [ForeignKey("IDProcessador")]
        public virtual Processador Processador { get; set; }

        public virtual ICollection<Hd> Hds { get; set; }

        public virtual ICollection<MemoriaRAM> MemoriaRAM { get; set; }
    }
}
