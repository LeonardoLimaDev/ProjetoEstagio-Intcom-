using ProjetoEstagio.Infra.Data.Infrastructure;
using ProjetoEstagio.Domain.Entities;
using ProjetoEstagio.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Infra.Data.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public Usuario Autenticado(Usuario usuario)
        {
            return _dbSet.Where(x => x.Login == usuario.Login && x.Senha == usuario.Senha).FirstOrDefault();
        }
    }
}
