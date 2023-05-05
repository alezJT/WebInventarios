using System.ComponentModel.DataAnnotations;

namespace WebInventarios.Models
{
    public class ProductoImagenes
    {
        [Display (Name ="ID de la Imagen")]
        public int ImagenID { get; set; }
        [Display (Name ="ID del Producto")]
        public int ProductoID { get; set; }
        [Display (Name ="Path de la Imagen")]
        public string PathImagen { get; set; }
    }
}
