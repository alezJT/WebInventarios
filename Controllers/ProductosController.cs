﻿using Microsoft.AspNetCore.Http;
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
        public async Task  <ActionResult> Create(Producto producto )
        {
            if( producto == null )
            {
                return View("No_es");
            }

            else
            {
                //var producto = new Producto()
                //{
                //    ProductoDesc = ProductoDesc ,
                //    ProductoComentario = ProductoDesc,
                //    ProductoCan = ProductoCan
                //};
                    
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

           
        }

        // GET: ProductosController/Edit/5
        public async Task <ActionResult> Edit(int proid = 0)
        {
            Producto producto = await _context.Productos.FindAsync(proid);

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
        [HttpGet]
        public ActionResult Delete(int id ,int oo)
        {
            return View("Delete");
        }

        // POST: ProductosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int ProductoId)
        {
            Producto producto =  await _context.Productos.FindAsync(ProductoId);
           
            
                _context.Remove(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            

        }
            
    }
}
