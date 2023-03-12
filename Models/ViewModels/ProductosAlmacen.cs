using System.ComponentModel.DataAnnotations;

namespace WebInventarios.Models.ViewModels
{
    public class ProductosAlmacen
    {
        [Display(Name = "Producto Codigo")]
        public int ProductoId { get; set; }

        [Display(Name = "Id del Almacen")]
        public int IDAlmacen { get; set; }

    }
}
