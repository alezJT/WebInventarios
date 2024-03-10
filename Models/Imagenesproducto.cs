namespace WebInventarios.Models
{
    public class Imagenesproducto
    {
        public int? imgID { get; set; }
        public int ProductoId { get; set; }
        public string imagen { get; set; }
        public string NombreArchivo { get; set; }

        public string ImageFullPath =>  imagen == String.Empty
            ? $"https://localhost:7220/imagenes/noImageProduct.jpg"
          : $"https://localhost:7220/Imagenes/productos/{NombreArchivo}";

        //    : $"https://localhost:7220/imagenes/Productos/" + imagenesproducto.FirstOrDefault().NombreArchivo
    }
}
