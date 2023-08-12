using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebInventarios.Models.ViewModels
{
    public class EditarProducto
    {
        public int ProductoId { get; set; }

        [Display(Name = "Producto Nombre")]
        public string? ProductoDesc { get; set; }

        [Display(Name = "Producto Comentario")]
        public string? ProductoComentario { get; set; }

        [Display(Name = "Producto Cantidad")]
        public decimal? ProductoCan { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un Almacen")]
        public int? IDAlmacen { get; set; }

      //  public IEnumerable<SelectListItem> Almacenes { get; set; }
    }
}
