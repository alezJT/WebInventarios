using System.ComponentModel.DataAnnotations;

namespace WebInventarios.Models.ViewModels
{
    public class ProductoViewModel
    {
        [Display(Name = "Codigo")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Se requiere el Nombre klk")]
        [Display(Name = "Nombre")]
        public string? ProductoDesc { get; set; }
    }
}
