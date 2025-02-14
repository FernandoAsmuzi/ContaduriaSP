using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace ContadSP.Services
{
    public class Utiles
    {
        public static async Task<string> CargarArchivoPdfAsync(IBrowserFile archivo, string abreviatura, string actaNum, string nombreComercial, IJSRuntime jsRuntime)
        {
            var maxAllowedSize = 10 * 1024 * 1024; // 10 MB

            if (archivo.Size > maxAllowedSize)
            {
                await jsRuntime.InvokeVoidAsync("showSweetAlert", "¡Error!", "El archivo excede el límite de tamaño", "error");
                return null;
            }

            var fechaActual = DateTime.Now.ToString("dd-MM-yyyy");
            var carpetaDestino = Path.Combine("wwwroot", "documentacion", "presupuestos", fechaActual);

            if (!Directory.Exists(carpetaDestino))
            {
                Directory.CreateDirectory(carpetaDestino);
            }

            var nuevoNombreArchivo = $"{abreviatura}-{actaNum}-{fechaActual}-{nombreComercial}.pdf";
            var rutaArchivo = Path.Combine(carpetaDestino, nuevoNombreArchivo);

            using (var stream = archivo.OpenReadStream(maxAllowedSize))
            using (var fileStream = new FileStream(rutaArchivo, FileMode.Create))
            {
                await stream.CopyToAsync(fileStream);
            }

            return rutaArchivo;
        }
    }
}
