using Blazored.SessionStorage;
using ContadSP.Pages.Login;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ContadSP.Extensiones
{
    public class AutenticacionExtension : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorage;

        public AutenticacionExtension(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sesion = await _sessionStorage.ObtenerSesion<SesionDTO>("sesion");
            if (sesion == null)
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, sesion.username),
                new Claim(ClaimTypes.Email, sesion.email),
                new Claim(ClaimTypes.Role, sesion.rol)
            }, "apiauth_type");
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public async Task AutenticarUsuario(SesionDTO sesion)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, sesion.username),
                new Claim(ClaimTypes.Email, sesion.email),
                new Claim(ClaimTypes.Role, sesion.rol)
            }, "apiauth_type");
            var usuario = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(usuario)));
        }

        public void CerrarSesion()
        {
            _sessionStorage.RemoveItemAsync("sesion");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        }
    }
}
