using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebInventarios.Models;

namespace WebInventarios.Helpers
{
    public class CombosHelpers : IComboshelpers
    {
        private readonly ConexionContext _conexion;

        public CombosHelpers (ConexionContext conexion)
        {
            _conexion = conexion;
        }

        public  async Task<IEnumerable<SelectListItem>> GetComboAlmacenes()
        {
            List<SelectListItem> selects = await _conexion.Almacenes.Select(a => new SelectListItem
            {
                Text = a.DescripcionAlmacen,
                Value = a.IDAlmacen.ToString()
            })
                .OrderBy(a => a.Text)
                .ToListAsync();

            selects.Insert(0, new SelectListItem { Text = "Seleccione un almacen", Value = "0" });
            return selects;
        }

       
    }
}
