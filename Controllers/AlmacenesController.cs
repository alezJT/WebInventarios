using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vereyon.Web;
using WebInventarios.Helpers;
using WebInventarios.Models;
using static WebInventarios.Helpers.ModalHelper;

namespace WebInventarios.Controllers
{
    public class AlmacenesController: Controller
    {
        private readonly ConexionContext _context;
        private readonly IFlashMessage _flashMessage;

        public AlmacenesController(ConexionContext context, IFlashMessage flashMessage)
        {
            _context = context;
            _flashMessage = flashMessage;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Crear(Almacenes model)
        {
            Almacenes almacenes = new()
            {
                IDAlmacen = model.IDAlmacen,
                DescripcionAlmacen = model.DescripcionAlmacen,
                ReferenciaAlmacen = model.ReferenciaAlmacen,
            };

            try
            {
                _context.Add(almacenes);
                await _context.SaveChangesAsync();
                _flashMessage.Confirmation("Registro creado.");
                return Json(new
                {
                    isValid = true,
                    html = ModalHelper.RenderRazorViewToString(this, "_ViewAllAlmacenes", _context.Almacenes
                    )
                });

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    ModelState.AddModelError(string.Empty, "Ya existe un producto con el mismo nombre.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
            }
            return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "Create", model) });

        }
    }
}
