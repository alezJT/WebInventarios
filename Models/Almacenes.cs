using System.ComponentModel.DataAnnotations;

namespace WebInventarios.Models
{
    public class Almacenes
    {
        [Display (Name ="Id del Almacen")]
        public int IDAlmacen { get; set; }

        [Display(Name = "Descripcion del Almacen")]
        public string? DescripcionAlmacen { get; set; }

        [Display(Name = "Referencia del Almacen")]
        public string? ReferenciaAmacen { get; set; }
    }
}
