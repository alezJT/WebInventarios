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

        // Navigation properties
        public Almacenes Almacenes { get; set; }
        public Producto Producto { get; set; }
        public ICollection<Producto> Productos { get; set; } // <-- nueva propiedad



    }
}
