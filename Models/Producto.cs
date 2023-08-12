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

        public ICollection<Almacenes>? Almacenes { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public ProductosAlmacen ProductosAlmacen { get; set; }
        public ICollection<ProductosAlmacen> productosAlmacen { get; set; }
        public ICollection<ProductoImagenes> productoImagenes { get; set; }

        public string ImagenFullPath => productoImagenes == null || productoImagenes.Count == 0
            ? $"http://localhost/images/noImageProduct.jpg"
            : productoImagenes.FirstOrDefault().PathImagen;
    }
}
