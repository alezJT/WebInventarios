using System.ComponentModel.DataAnnotations;
using WebInventarios.Models.ViewModels;

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

        //public ICollection<Almacenes>? Almacenes { get; set; }

        public ProductosAlmacen ProductosAlmacen1 { get; set; }
        public ICollection<ProductosAlmacen> productosAlmacen { get; set; }
    }
}
