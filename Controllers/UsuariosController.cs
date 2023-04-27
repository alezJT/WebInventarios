using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebInventarios.Models;
using static WebInventarios.Helpers.ModalHelper;

namespace WebInventarios.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ConexionContext _context;

        public UsuariosController(ConexionContext context)
        {
            _context = context;
        }
      
        public async Task <IActionResult> Index()
        {
            return View( await _context.Usuarios.ToListAsync());
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuariosController/Create
        [NoDirectAccess]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create( Usuarios usuarios)
        {
            try
            {
                _context.Usuarios.Add(usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Edit/5
        public async Task <IActionResult> Edit(int IdUsuarios)
        {
            if (IdUsuarios > 0)
            {
                Usuarios usuarios = await _context.Usuarios.FindAsync(IdUsuarios);
                return View(usuarios);
            }
              else
            {
                return RedirectToAction(nameof(Create));
            }
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Usuarios usuarios)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(usuarios);

                }
                //if (usuarios == null)
                //{
                //    return View();
                //}
                 _context.Update(usuarios);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: UsuariosController/Delete/5
        [NoDirectAccess]

        public async Task <IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                Usuarios usuarios = await _context.Usuarios.FindAsync(id);

                if (usuarios == null)
                {
                    return NotFound();
                }

                _context.Remove(usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
