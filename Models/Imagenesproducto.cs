namespace WebInventarios.Models
{
    public class Imagenesproducto
    {
        public int? imgID { get; set; }
        public int ProductoId { get; set; }
        public string imagen { get; set; }

        public string ImageFullPath =>  imagen == String.Empty
            ? $"https://localhost:7228/images/noImageProduct.jpg"
          : $"http://localhost/Imagenes/products/{imagen}";

    }
}
