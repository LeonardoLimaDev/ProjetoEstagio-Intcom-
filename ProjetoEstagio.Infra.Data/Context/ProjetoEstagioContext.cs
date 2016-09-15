using ProjetoEstagio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Infra.Data.Context
{
    public class ProjetoEstagioContext : DbContext
    {
        public ProjetoEstagioContext()
            : base("BancoProjetoEstagio")
        {
            
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Computador> Computador { get; set; }
        public DbSet<PlacaMae> PlacaMae { get; set; }
        public DbSet<Processador> Processador { get; set; }
        public DbSet<Hd> Hds { get; set; }
        public DbSet<MemoriaRAM> MemoriaRAM { get; set; }
    }
}
