namespace WebInventarios.Models
{
    public class CrearProductosViewModel : Producto
    {
        public ICollection<Almacenes>? Almacenes { get; set; }
    }
}
