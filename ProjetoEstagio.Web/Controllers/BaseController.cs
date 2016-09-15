using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ProjetoEstagio.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public string ObterIdUsuarioLogado()
        {
            return HttpContext.User.Identity.Name;
        }

        //Implementação da Data Annotation para implementação de multiplos botões submit
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public class MultipleButtonAttribute : ActionNameSelectorAttribute
        {
            public string Name { get; set; }
            public string Argument { get; set; }

            public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
            {
                var isValidName = false;
                var keyValue = string.Format("{0}:{1}", Name, Argument);
                var value = controllerContext.Controller.ValueProvider.GetValue(keyValue);

                if (value != null)
                {
                    controllerContext.Controller.ControllerContext.RouteData.Values[Name] = Argument;
                    isValidName = true;
                }

                return isValidName;
            }
        }
    }
}