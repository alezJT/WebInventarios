using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebInventarios.Models
{
    public class CrearProductosViewModel : Producto
    {

        [Display(Name = "Almacen")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una Almacen.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int IDAlmacen { get; set; }
        public ICollection<Almacenes>? Almacenes1 { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una Almacen.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public IEnumerable<SelectListItem>? Almacenes { get; set; }

        [Display(Name = "Foto")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public IFormFile ImageFile { get; set; }
    }
}
