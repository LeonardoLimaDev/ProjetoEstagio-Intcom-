using ProjetoEstagio.Domain.Entities;
using ProjetoEstagio.Domain.Interfaces.Repository;
using ProjetoEstagio.Infra.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Infra.Data.Repositories
{
    public class PlacaMaeRepository : GenericRepository<PlacaMae>, IPlacaMaeRepository
    {
    }
}
