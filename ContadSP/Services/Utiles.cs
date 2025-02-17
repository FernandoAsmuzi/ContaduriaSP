using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace ContadSP.Services
{
    public class Utiles
    {
        public static async Task<string> CargarArchivoPdfAsync(IBrowserFile archivo, string carpetaDestino, string nombreArchivo, IJSRuntime jsRuntime)
        {
            var maxAllowedSize = 10 * 1024 * 1024; // 10 MB

            if (archivo.Size > maxAllowedSize)
            {
                await jsRuntime.InvokeVoidAsync("showSweetAlert", "¡Error!", "El archivo excede el límite de tamaño", "error");
                return null;
            }

            if (!Directory.Exists(carpetaDestino))
            {
                Directory.CreateDirectory(carpetaDestino);
            }

            var rutaArchivo = Path.Combine(carpetaDestino, nombreArchivo);

            using (var stream = archivo.OpenReadStream(maxAllowedSize))
            using (var fileStream = new FileStream(rutaArchivo, FileMode.Create))
            {
                await stream.CopyToAsync(fileStream);
            }

            return rutaArchivo;
        }
    }
}
