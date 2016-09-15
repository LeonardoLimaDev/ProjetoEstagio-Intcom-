using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Infra.IoC
{
    public class Container
    {
        public Container()
        {
        }

        public void GetModule(IKernel kernel)
        {
            kernel.Load(new NinjectModulo());
        }
    }
}
