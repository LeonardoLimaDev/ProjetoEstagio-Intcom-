using ProjetoEstagio.Application.AppServices.Interfaces;
using ProjetoEstagio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjetoEstagio.Web.Controllers
{
    public class ComputadorController : BaseController
    {
        private readonly IFuncionarioAppService _funcionarioAppService;
        private readonly IEmpresaAppService _empresaAppService;
        private readonly IComputadorAppService _computadorAppService;
        private readonly IMemoriaRAMAppService _memoriaRAMAppService;
        private readonly IHdAppService _hdAppService;

        public ComputadorController(IFuncionarioAppService funcionarioAppService,
                                    IEmpresaAppService empresaAppService,
                                    IComputadorAppService computadorAppService,
                                    IMemoriaRAMAppService memoriaRAMAppService,
                                    IHdAppService hdAppService)
        {
            _funcionarioAppService = funcionarioAppService;
            _empresaAppService = empresaAppService;
            _computadorAppService = computadorAppService;
            _memoriaRAMAppService = memoriaRAMAppService;
            _hdAppService = hdAppService;
        }


        // GET: Computador
        public ActionResult Lista()
        {
            string IdUsuario = ObterIdUsuarioLogado();

            int IdUser;

            Int32.TryParse(IdUsuario,out IdUser);
            try
            {
                ViewBag.Title = "Lista Computadores";
                var funcionario = _funcionarioAppService.GetFuncionarioByIdUsuario(IdUser);
                ViewBag.NomeFuncionario = funcionario.Nome;

                ViewBag.NomeEmpresa = _empresaAppService.GetNomeEmpresaById(funcionario.IDEmpresa);

                List<ComputadorViewModel> model = _computadorAppService.GetComputadoresByIdEmpresa(funcionario.IDEmpresa);

                foreach (var item in model)
                {
                    foreach (var hd in item.Hds)
                    {
                        int capacidade;
                        Int32.TryParse(hd.Capacidade, out capacidade);

                        item.CapacidadeTotalHd += capacidade;
                    }

                    foreach (var memoriaRAM in item.MemoriaRAM)
                    {
                        int capacidade;
                        Int32.TryParse(memoriaRAM.Capacidade, out capacidade);

                        item.CapacidadeTotalMemoriaRAM += capacidade;
                    }
                }

                return View(model);
            }
            catch (Exception)
            {

                return RedirectToAction("Login", "Account");
            }
            
        }

        #region Actions Create's
        [HttpGet]
        public ActionResult CreateComputador()
        {
            ComputadorViewModel computador = new ComputadorViewModel();

            return PartialView(computador);
        }

        [HttpPost]
        public ActionResult CreateComputador(ComputadorViewModel model)
        {
            string IdUsuario = ObterIdUsuarioLogado();

            int IdUser;
            Int32.TryParse(IdUsuario,out IdUser);
            try
            {
                if (ModelState.IsValid)
                {
                    var funcionario = _funcionarioAppService.GetFuncionarioByIdUsuario(IdUser);
                    
                    model = _computadorAppService.Create(model,funcionario.IDEmpresa);
                    return RedirectToAction("CreateHd", new { IdComputador = model.ID });
                }
                ModelState.AddModelError("", "");
                
            }
            catch
            {
                ModelState.AddModelError("", "");
                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateHd(int IdComputador)
        {
            HdViewModel hd = new HdViewModel();
            hd.IdComputadorUltimo = IdComputador;
            return View(hd);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "CreateHd")] //Data Annotation para permitir multiplos botões submit
        public ActionResult CreateHd(HdViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _hdAppService.Create(model, model.IdComputadorUltimo);
                    return RedirectToAction("CreateMemoriaRAM", new { IdComputador = model.IdComputadorUltimo });
                }
                ModelState.AddModelError("", "");
                
            }
            catch
            {
                ModelState.AddModelError("", "");
                return View();
            }
            return View();
        }
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "CreateHdMais")]
        public ActionResult CreateHdMais(HdViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _hdAppService.Create(model, model.IdComputadorUltimo);
                    return RedirectToAction("CreateHd", new { IdComputador = model.IdComputadorUltimo });
                }
                ModelState.AddModelError("", "");

            }
            catch
            {
                ModelState.AddModelError("", "");
                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateMemoriaRAM(int IdComputador)
        {
            MemoriaRAMViewModel memoriaRAM = new MemoriaRAMViewModel();
            memoriaRAM.IdComputadorUltimo = IdComputador;
            return View(memoriaRAM);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "CreateMemoriaRAM")]
        public ActionResult CreateMemoriaRAM(MemoriaRAMViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _memoriaRAMAppService.Create(model, model.IdComputadorUltimo);
                    return RedirectToAction("Lista");
                }
                ModelState.AddModelError("", "");
                
            }
            catch
            {
                ModelState.AddModelError("", "");
                return View();
            }
            return View();
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "CreateMemoriaRAMMais")]
        public ActionResult CreateMemoriaRAMMais(MemoriaRAMViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _memoriaRAMAppService.Create(model, model.IdComputadorUltimo);
                    return RedirectToAction("CreateMemoriaRAM", new { IdComputador = model.IdComputadorUltimo });
                }
                ModelState.AddModelError("", "");

            }
            catch
            {
                ModelState.AddModelError("", "");
                return View();
            }
            return View();
        }
        #endregion

        #region Actions Edit's
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                ComputadorViewModel computador = new ComputadorViewModel();

                computador = _computadorAppService.GetById(id);

                return View(computador);
            }
            catch
            {
                ModelState.AddModelError("", "");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(ComputadorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _computadorAppService.Edit(model,model.IdEmpresaEdit);
                    return RedirectToAction("EditHdSelecao", new { IdComputador = model.ID });
                }
                ModelState.AddModelError("", "");

            }
            catch
            {
                ModelState.AddModelError("", "");
                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditHdSelecao(int IdComputador)
        {
            ComputadorViewModel computador = _computadorAppService.GetById(IdComputador);

            List<HdViewModel> Hds = new List<HdViewModel>();

            foreach (var hd in computador.Hds)
            {
                hd.IdComputadorUltimo = IdComputador;
                Hds.Add(hd);
            }

            return View(Hds);
        }

        [HttpGet]
        public ActionResult EditHd(HdViewModel model)
        {
            
            return View(model);
        }

        [HttpPost, ActionName("EditHd")]
        public ActionResult EditHdPost(HdViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _hdAppService.Edit(model,model.IdComputadorUltimo);
                    return RedirectToAction("EditHdSelecao", new { IdComputador = model.IdComputadorUltimo });
                }
                ModelState.AddModelError("", "");

            }
            catch
            {
                ModelState.AddModelError("", "");
                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditHdMais(HdViewModel model)
        {

            return View(model);
        }

        [HttpPost, ActionName("EditHdMais")]
        public ActionResult EditHdMaisPost(HdViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _hdAppService.Create(model, model.IdComputadorUltimo);
                    return RedirectToAction("EditHdSelecao", new { IdComputador = model.IdComputadorUltimo });
                }
                ModelState.AddModelError("", "");

            }
            catch
            {
                ModelState.AddModelError("", "");
                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditMemoriaRAMSelecao(HdViewModel model)
        {
            ComputadorViewModel computador = _computadorAppService.GetById(model.IdComputadorUltimo);

            List<MemoriaRAMViewModel> memoriaRAMs = new List<MemoriaRAMViewModel>();

            foreach (var memoria in computador.MemoriaRAM)
            {
                memoria.IdComputadorUltimo = model.IdComputadorUltimo;
                memoriaRAMs.Add(memoria);
            }

            return View(memoriaRAMs);
        }

        [HttpGet]
        public ActionResult EditMemoriaRAMSelecaoId(int IdComputador)
        {
            ComputadorViewModel computador = _computadorAppService.GetById(IdComputador);

            List<MemoriaRAMViewModel> memoriaRAMs = new List<MemoriaRAMViewModel>();

            foreach (var memoria in computador.MemoriaRAM)
            {
                memoria.IdComputadorUltimo = IdComputador;
                memoriaRAMs.Add(memoria);
            }

            return View(memoriaRAMs);
        }

        [HttpGet]
        public ActionResult EditMemoriaRAM(MemoriaRAMViewModel model)
        {

            return View(model);
        }

        [HttpPost, ActionName("EditMemoriaRAM")]
        public ActionResult EditMemoriaRAMPost(MemoriaRAMViewModel model)
        {
            try
            {   
                if (ModelState.IsValid)
                {
                    _memoriaRAMAppService.Edit(model, model.IdComputadorUltimo);
                    return RedirectToAction("EditMemoriaRAMSelecaoId", new { IdComputador = model.IdComputadorUltimo });
                }
                ModelState.AddModelError("", "");

            }
            catch
            {
                ModelState.AddModelError("", "");
                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditMemoriaRAMMais(MemoriaRAMViewModel model)
        {

            return View(model);
        }

        [HttpPost, ActionName("EditMemoriaRAMMais")]
        public ActionResult EditMemoriaRAMMaisPost(MemoriaRAMViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _memoriaRAMAppService.Create(model, model.IdComputadorUltimo);
                    return RedirectToAction("EditMemoriaRAMSelecaoId", new { IdComputador = model.IdComputadorUltimo });
                }
                ModelState.AddModelError("", "");

            }
            catch
            {
                ModelState.AddModelError("", "");
                return View();
            }
            return View();
        }
        #endregion

        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                ComputadorViewModel computador = new ComputadorViewModel();

                computador = _computadorAppService.GetById(id);


                return View(computador);
            }
            catch
            {
                ModelState.AddModelError("", "");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                ComputadorViewModel computador = new ComputadorViewModel();

                computador = _computadorAppService.GetById(id);
                

                return View(computador);
            }
            catch
            {
                ModelState.AddModelError("", "");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(ComputadorViewModel modal)
        {
            try
            {
                _computadorAppService.DeleteById(modal.ID);

                return RedirectToAction("Lista", "Computador");
            }
            catch
            {
                ModelState.AddModelError("", "");
                return View();
            }
        }
        
    }
}