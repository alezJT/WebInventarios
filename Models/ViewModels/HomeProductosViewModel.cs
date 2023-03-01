using WebInventarios.Comun;

namespace WebInventarios.Models.ViewModels

{
    public class HomeProductosViewModel
    {
        public ListasPaginada<Producto>? Productos { get; set; }
    }
}
