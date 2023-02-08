using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebInventarios.Models;
using static WebInventarios.Helpers.ModalHelper;

namespace WebInventarios.Controllers
{
    public class AlmacenesController: Controller
    {
        private readonly ConexionContext _context;

        public AlmacenesController(ConexionContext context)
        {
            _context = context;
        }

        public async Task <IActionResult> Index()
        {
            return View(await _context.Almacenes.ToListAsync());
        }

        [NoDirectAccess]
        public async Task<IActionResult> Crear()
        {
            return View();
        }

    }
}
