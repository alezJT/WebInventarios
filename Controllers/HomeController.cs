using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing.Printing;
using WebInventarios.Comun;
using WebInventarios.Models;
using WebInventarios.Models.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebInventarios.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConexionContext _context;

        public HomeController(ILogger<HomeController> logger, ConexionContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber, int? IDAlmacen)
        {



            if (searchString != null)
            {
                pageNumber = 1;
            }
            IQueryable<Producto> query = _context.Productos
                                                 .Include(ip => ip.imagenesproducto);

            query = query.Where(p => p.ProductoCan > 0);

            int pageSize = 8;

            IQueryable<Almacenes> almacenes = _context.Almacenes;


            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p => (p.ProductoDesc.ToLower().Contains(searchString.ToLower())));
            }


            HomeProductosViewModel model = new()
            {
                Productos = await ListasPaginada<Producto>.CreateAsync(query, pageNumber ?? 1, pageSize),
                Almacenes = await ListasPaginada<Almacenes>.CreateAsync(almacenes, pageNumber ?? 1, pageSize),

            };

            return View(model);
            
           
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task <IActionResult> Detalle(int? id)
        {
            Producto producto = await _context.Productos.FindAsync(id);
            AddProductToCartViewModel modelo = new()
            {
                Categorias = "",
                Nombre = producto.ProductoDesc,
                Descripcion = producto.ProductoComentario,
                
            };
            return View(modelo);
        }

    }
}