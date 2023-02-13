using System.ComponentModel.DataAnnotations;

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
    }
}
