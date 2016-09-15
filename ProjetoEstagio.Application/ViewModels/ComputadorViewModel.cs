using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstagio.Application.ViewModels
{
    public class ComputadorViewModel
    {

        public ComputadorViewModel()
        {
            if (this.Hds == null)
            {
                this.Hds = new List<HdViewModel>();
            }
            if (this.MemoriaRAM == null)
            {
                this.MemoriaRAM = new List<MemoriaRAMViewModel>();
            }   
        }

        public int ID { get; set; }

        //public EmpresaViewModel Empresa { get; set; }

        public PlacaMaeViewModel PlacaMae { get; set; }

        public ProcessadorViewModel Processador { get; set; }

        public ICollection<HdViewModel> Hds { get; set; }

        public ICollection<MemoriaRAMViewModel> MemoriaRAM { get; set; }


        public virtual int IdEmpresaEdit { get; set; }
        public virtual float CapacidadeTotalHd { get; set; }
        public virtual float CapacidadeTotalMemoriaRAM { get; set; }
    }
}
