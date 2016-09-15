using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Domain.Entities
{
    public class Funcionario
    {

        public virtual int ID { get; set; }

        [Column("IDUsuario")]
        public int IDUsuario { get; set; }

        [Column("IDEmpresa")]
        public int IDEmpresa { get; set; }

        public virtual string Nome { get; set; }

        [ForeignKey("IDUsuario")]
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("IDEmpresa")]
        public Empresa Empresa { get; set; }
    }
}
