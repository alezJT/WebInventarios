using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebInventarios.Models;
using WebInventarios.Helpers;
using static WebInventarios.Helpers.ModalHelper;
using WebInventarios.Comun;
using WebInventarios.Models.ViewModels;

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
        [NoDirectAccess]
        public async Task<IActionResult> Create()
        {


            CrearProductosViewModel model = new()
            {
                Almacenes = _context.Almacenes.ToList(),

            };
            return View(model);
        }

        // POST: ProductosController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task  <ActionResult> Create(Producto producto, int IDAlmacen)
        {
            if( producto == null )
            {
                return View("No_es");
            }

            else
            {
                if (IDAlmacen > 0)
                {
                   var NEWProductosAlmacen =  new ProductosAlmacen 
                    {
                        IDAlmacen = IDAlmacen,
                        ProductoId = producto.ProductoId
                    };

                    _context.ProductosAlmacens.Add(NEWProductosAlmacen);
                    await _context.SaveChangesAsync();
                }

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
           
           
        }

        // GET: ProductosController/Edit/5
        [NoDirectAccess]
        public async Task <ActionResult> Edit(int ProductoID = 0)
        {
            Producto producto = await _context.Productos.FindAsync(ProductoID);

            if ( producto == null )
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: ProductosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(int id, Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return View(producto);

            }
            else
            {
                _context.Update(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }

        // GET: ProductosController/Delete/5
        //[HttpGet]
        //public ActionResult Delete(int id ,int oo)
        //{
        //    return View("Delete");
        //}

        //// POST: ProductosController/Delete/5

        [NoDirectAccess]
        public async Task<ActionResult> Delete(int Id)
        {
            Producto producto =  await _context.Productos.FindAsync(Id);

            if (producto == null)
            {
                return NotFound();
            }
            _context.Remove(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            

        }


            
    }
}
