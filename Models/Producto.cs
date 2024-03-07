using System.ComponentModel.DataAnnotations;
using WebInventarios.Models.ViewModels;
using static System.Net.WebRequestMethods;


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

        public ICollection<Almacenes>? Almacenes { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public ProductosAlmacen ProductosAlmacen { get; set; }
        public ICollection<ProductosAlmacen> productosAlmacen { get; set; }
        public ICollection<Imagenesproducto> imagenesproducto { get; set; }

        public string ImagenFullPath => imagenesproducto == null || imagenesproducto.Count == 0
            ? $"https://localhost:7220/imagenes/noImageProduct.jpg"
            : $"https://localhost:7220/imagenes/Productos/" + imagenesproducto.FirstOrDefault().NombreArchivo;

    }
}
