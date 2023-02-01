using System.ComponentModel.DataAnnotations;

namespace WebInventarios.Models
{
    public partial class Producto
    {
        [Display(Name = "Producto Codigo")]
        public int ProductoId { get; set; }

        [Display(Name = "Producto Nombre")]
        public string? ProductoDesc { get; set; }

        [Display(Name = "Producto Comentario")]
        public string? ProductoComentario { get; set; }

        [Display(Name = "Producto Cantidad")]
        public decimal? ProductoCan { get; set; }
    }
}
