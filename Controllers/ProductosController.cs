﻿using Microsoft.AspNetCore.Http;
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
        private readonly IComboshelpers _combos;

        public ProductosController(ConexionContext  context, IComboshelpers combos)
        {
            _context = context;
            _combos = combos;
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
                Almacenes = await _combos.GetComboAlmacenes(),

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
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();

                //  int ProductoID = await _context.Productos.FindAsync(producto.ProductoDesc);

                var Productos = await _context.Productos.Where(p=> p.ProductoDesc == producto.ProductoDesc).FirstOrDefaultAsync();

                if (IDAlmacen > 0)
                {
                    var NEWProductosAlmacen = new ProductosAlmacen
                    {
                        IDAlmacen = IDAlmacen,
                        ProductoId = Productos.ProductoId
                    };

                    _context.ProductosAlmacen.Add(NEWProductosAlmacen);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
          

        }

        // GET: ProductosController/Edit/5
        [NoDirectAccess]
        public async Task <ActionResult> Edit(int ProductoID = 0)
        {
            if (ProductoID > 0)

            {
             
                

                Producto producto = await _context.Productos.FindAsync(ProductoID);
                CrearProductosViewModel model = new()
                {
                    Almacenes = await _combos.GetComboAlmacenes(),
                    ProductoId = producto.ProductoId,
                    ProductoDesc = producto.ProductoDesc,
                    ProductoComentario = producto.ProductoComentario,
                    ProductoCan = producto.ProductoCan,
                };
                return View(model);
             }
            
             else
                {
                    return RedirectToAction("Index");
                }
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
                if (producto.productosAlmacen == null)
                {
                    ProductosAlmacen productosAlmacen = await _context.ProductosAlmacen.FindAsync(producto.ProductoId);
                }

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
