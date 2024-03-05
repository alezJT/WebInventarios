
namespace WebInventarios.Helpers
{
    public class SubidasHelper : ISubidasHelper
    {
        private readonly string _Carpeta;

        public SubidasHelper(String Carpeta)
        {
            _Carpeta = Carpeta;
        }

        public async Task<string>GuardarArchivoAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("El archivo no es valido");

            // gerenar Nonbre del Archivo
            string nombreArchivo = Guid.NewGuid().ToString()+ Path.GetExtension(file.FileName);

            // Ruta completa del archivo
            string rutaCompleta = Path.Combine(_Carpeta, nombreArchivo);

            // Guardar el archivo en disco
            using (var stream = new FileStream(rutaCompleta, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return nombreArchivo; // Retorna el nombre del archivo Guardado
        }

    }
}
