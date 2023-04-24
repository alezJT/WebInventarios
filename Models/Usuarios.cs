using System.ComponentModel.DataAnnotations;

namespace WebInventarios.Models
{
    public class Usuarios
    {
        [Display(Name ="Id de Usuario") ]
        public int IdUsuario { get; set; }

        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Display(Name = "Nombre/ apellido de Usuario")]
        public string UsuarioNombre { get; set; }

        [Display(Name = "Clave de Usuario")]
        public string Clave { get; set; }

    }
}
