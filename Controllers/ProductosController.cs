using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebInventarios.Models;

namespace WebInventarios.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ConexionContext _context;

        public ProductosController(ConexionContext  context)
        {
            _context = context;
        }
        // GET: ProductosController
        public async Task <IActionResult> Index()
        {
            return View(await _context.Productos.ToListAsync());
        }

        // GET: ProductosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task  <ActionResult> Create(string ProductoDesc )
        {
            if( ProductoDesc == null )
            {
                return View("No_es");
            }

            else
            {
                var producto = new Producto()
                {
                    ProductoDesc = ProductoDesc 
                };
                    
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosController/Edit/5
        public ActionResult Edit(int proid)
        {
            return View(proid);
        }

        // POST: ProductosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
