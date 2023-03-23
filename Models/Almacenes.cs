using System.ComponentModel.DataAnnotations;
using WebInventarios.Models.ViewModels;

namespace WebInventarios.Models
{
    public class Almacenes
    {
        [Display (Name ="Id del Almacen")]
        public int IDAlmacen { get; set; }

        [Display(Name = "Descripcion del Almacen")]
        //[Required(ErrorMessage ="El campo {0} es requerido")]
        public string? DescripcionAlmacen { get; set; }

        [Display(Name = "Referencia del Almacen")]
        public string? ReferenciaAlmacen { get; set; }

        public ICollection<Producto> producto { get; set; }
        public ProductosAlmacen ProductosAlmacen1 { get; set; }
        public ICollection<ProductosAlmacen>productosAlmacen { get; set; }
    }
}
