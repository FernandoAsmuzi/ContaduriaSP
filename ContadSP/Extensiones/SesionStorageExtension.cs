using Blazored.SessionStorage;
using System.Text.Json;
using System.Text;


namespace ContadSP.Extensiones
{
    public static class SesionStorageExtension
    {
        public static async Task GuardarSesion(this ISessionStorageService sessionStorage, string key, object value)
        {
            var json = JsonSerializer.Serialize(value);
            await sessionStorage.SetItemAsync(key, json);
        }

        public static async Task<T?> ObtenerSesion<T>(this ISessionStorageService sessionStorage, string key)
        {
            var json = await sessionStorage.GetItemAsStringAsync(key);
            if (json == null)
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
