using ContadSP.Models;
using System.Linq.Expressions;

namespace ContadSP.Repositorios
{
    public interface IRepositorio<T> where T : class
    {
        // Metodos generales
        Task<IEnumerable<T>> ObtenerTodo();
        Task<T> ObtenerPorId(int id);
        Task<T> Agregar(T entidad);
        Task<T> Actualizar(T entidad);
        Task<T> Eliminar(int id);
        // Fin metodos generales

        // Metodos especificos

        // ARTICULOS
        Task<List<Models.Articulo>> Buscar(string buscar);
        Task<IEnumerable<Models.Articulo>> ObtenerArticulos();
        Task<IEnumerable<Models.Pedido>> ObtenerPedidos();
        Task<Models.Pedido> ObetnerPedidoPorId(int id);
        Task<int> ObtenerUltimaProvision();
        Task<Models.Provision> ObtenerProvisionPorId(int id);
        Task<IEnumerable<Models.Provision>> ObtenerProvisiones();
        
        
        Task<ProcesoPedido> ObtenerUltimoProcesoNumero(int id);
        Task<int> ObtenerUltimoProcesoPedidoId();
        Task<Pedido> ObtenerUltimoPedido();
        Task<IEnumerable<DetalleProvision>> ObtenerProvisionesId(int id);
        Task<Pedido> ObteberPedidoPorProvisionId(int id);
        Task<IEnumerable<PedidoProveedor>> ObtenerPedidoProveedorPorPedidoId(int id);


        Task<Models.ProvisionExp> ObtenerProvisionExpPorId(int id);
        Task<IEnumerable<Models.ProvisionExp>> ObtenerProvisionExp();
        Task<ProvisionExp> ObtenerUltimaProvisionExp();
        Task CambiarEstadoProvision(object entidad, int estado);

        Task<ProcesoPedido> ObtenerProcesoPedidoPorPedidoId(int id);

        // Fin metodos especificos
    }
}
