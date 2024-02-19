using Microsoft.AspNetCore.Mvc;

namespace WebInventarios.Controllers
{
    public class CuentasControllercs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

    }

}
