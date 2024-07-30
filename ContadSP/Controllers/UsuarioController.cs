using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContadSP.Pages.Login;
using ContadSP.Data;
using Microsoft.EntityFrameworkCore;

namespace ContadSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ContadSPContext _context;

        public UsuarioController(ContadSPContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<SesionDTO>> Login(LoginDTO login)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.nombre_usuario == login.username && u.password == login.password);
            if (usuario == null)
            {
                return NotFound();
            }
            return new SesionDTO
            {
                username = usuario.nombre_usuario,
                email = usuario.email,
                rol = usuario.rol
            };
        }
    }
}
