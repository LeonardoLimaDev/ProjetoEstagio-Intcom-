using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Domain.Interfaces.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Create(T computador);
        void DeleteById(int id);
        void Edit(T computador);
        void SaveChanges();
        T Get(Func<T, bool> preticate);
        List<T> GetList(Func<T, bool> preticate);
    }
}
