using ProjetoEstagio.Domain.Interfaces.Generic;
using ProjetoEstagio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Usuario Autenticado(Usuario usuario);
    }
}
