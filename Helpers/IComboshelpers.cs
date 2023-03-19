

using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebInventarios.Helpers
{
    public interface IComboshelpers
    {
        Task<IEnumerable<SelectListItem>> GetComboAlmacenes();
    }
}
