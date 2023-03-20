using System.ComponentModel.DataAnnotations;

namespace WebInventarios.Models.ViewModels
{
    public class ProductosAlmacen
    {
        public int Id { get; set; }

        [Display(Name = "Producto Codigo")]
        public int ProductoId { get; set; }

        [Display(Name = "Id del Almacen")]
        public int IDAlmacen { get; set; }

    }
}
