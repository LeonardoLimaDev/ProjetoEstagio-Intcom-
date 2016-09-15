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
    public class AccountController : BaseController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public AccountController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    model = _usuarioAppService.Autenticado(model);

                    if (model != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.ID.ToString(), false);

                        int IdUsuario = model.ID;

                        return RedirectToAction("Lista", "Computador");
                    }
                    else
                        ModelState.AddModelError("", "Login ou Senha inválido.");
                }
                else
                    ModelState.AddModelError("", "");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "");
            }
            return View();
        }
    
        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return Redirect("Login");
        }
    }
}