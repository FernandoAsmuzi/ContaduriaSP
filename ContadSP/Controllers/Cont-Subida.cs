using Microsoft.AspNetCore.Mvc;

namespace ContadSP.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class Cont_Subida : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(IFormFile file)
        {
            var path = Path.Combine("C:\\Users\\jbaiud\\Pictures", file.FileName);

            // Verificar y crear el directorio si no existe
            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Guardar el archivo
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Ok(new { path });
        }
    }
}
