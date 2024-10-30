using ContadSP.Data;
using ContadSP.Models;
using ContadSP.Repositorios;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Metadata.Internal;
using System.Linq.Expressions;

public class Repositorio<T> : IRepositorio<T> where T : class
{
    protected readonly ContadSPContext _context;
    private readonly DbSet<T> _dbSet;

    public Repositorio(ContadSPContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    // METODOS GENERALES
    public async Task<IEnumerable<T>> ObtenerTodo()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task<T> ObtenerPorId(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    public async Task<T> Agregar(T entidad)
    {
        var result = await _dbSet.AddAsync(entidad);
        await _context.SaveChangesAsync();
        return result.Entity;
    }
    public async Task<T> Actualizar(T entidad)
    {
        var result = _dbSet.Update(entidad);
        await _context.SaveChangesAsync();
        return result.Entity;
    }
    public async Task<T> Eliminar(int id)
    {
        var entidad = await _dbSet.FindAsync(id);
        if (entidad == null)
        {
            return null;
        }
        var result = _dbSet.Remove(entidad);
        await _context.SaveChangesAsync();
        return result.Entity;
    }
    // Fin metodos generales

    // ------------ METODOS ESPECIFICOS ----------------------

    // METODOS PARA PROVISION
    public async Task<int> ObtenerUltimaProvision()
    {
        var ultima = await _context.Provision
        .OrderByDescending(a => a.id)
        .Select(a => a.id)
        .FirstOrDefaultAsync();
        return ultima;
    }
    public async Task<Provision> ObtenerProvisionPorId(int id)
    {
        return await _context.Provision
            .Include(p => p.Destino)
            .Include(p => p.Usuario)
            .Include(p => p.TipoPedido)
            .FirstAsync(p => p.id == id);
    }
    public async Task<IEnumerable<Provision>> ObtenerProvisiones()
    {
        return await _context.Provision
            .Include(p => p.Destino)
            .Include(p => p.Usuario)
            .ToListAsync();
    }

    public async Task CambiarEstadoProvision(object entidad, int estado)
    {

        if (entidad is Provision provision)
        {
            provision.estado_id = estado;
            _context.Provision.Update(provision);
        }

        await _context.SaveChangesAsync();
    }

    // ---------------------------------------------------------
    // METODOS PARA DETALLE PROVISION
    public async Task<IEnumerable<DetalleProvision>> ObtenerProvisionesId(int id)
    {
        return await _context.DetalleProvision
            .Include(d => d.Articulo)
            .Include(d => d.Articulo.Categoria)
            .Include(d => d.Provision)
            .Include(d => d.Provision.Destino)
            .Include(d => d.Provision.Usuario)
            .Include(d => d.UnidadMedida)
            .Where(d => d.provision_id == id)
            .ToListAsync();
    }


    // ---------------------------------------------------------
    // METODOS PARA ARTICULO
    public async Task<List<Articulo>> Buscar(string buscar)
    {
        var resultados = await _context.Articulo.Where(a => a.descripcion.Contains(buscar)).ToListAsync();
        return resultados;
    }
    public async Task<IEnumerable<Articulo>> ObtenerArticulos()
    {
        return await _context.Articulo
            .Include(a => a.Categoria)
            .ToListAsync();
    }

    // ---------------------------------------------------------
    // METODOS PARA PEDIDO
    public async Task<Pedido> ObetnerPedidoPorId(int id)
    {
        return await _context.Pedido
            .Include(p => p.Provision)
            .FirstAsync(p => p.id == id);
    }
    public async Task<IEnumerable<Pedido>> ObtenerPedidos()
    {
        return await _context.Pedido
            .Include(p => p.Provision)
            .ToListAsync();
    }
    public async Task<Pedido> ObtenerUltimoPedido()
    {
        var ultima = await _context.Pedido
        .OrderByDescending(a => a.id)

        .FirstOrDefaultAsync();
        return ultima;
    }
    public async Task<Pedido> ObteberPedidoPorProvisionId(int id)
    {
        return await _context.Pedido
            .Include(p => p.Provision)
            .FirstAsync(p => p.provision_id == id);
    }

    // ---------------------------------------------------------
    // METODOS PARA PEDIDO PROVEEDOR
    public async Task<IEnumerable<PedidoProveedor>> ObtenerPedidoProveedorPorPedidoId(int id)
    {
        return await _context.PedidoProveedor
            .Include(p => p.Pedido)
            .Include(p => p.Proveedor)
            .Where(p => p.pedido_id == id)
            .ToListAsync();
    }
    public async Task CambiarCarga(int prov_id, int ped_id)
    {
        var pedidoProveedor = await _context.PedidoProveedor
            .FirstOrDefaultAsync(pp => pp.proveedor_id == prov_id && pp.pedido_id == ped_id);

        if (pedidoProveedor != null)
        {
            pedidoProveedor.carga = true;
            _context.PedidoProveedor.Update(pedidoProveedor);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<PedidoProveedor> ObtenerPedidoProveedorPorPedidoYProveedor(int id_pedido, int id_proveedor)
    {
        var pp = await _context.PedidoProveedor
            .Include(p => p.Pedido)
            .Include(p => p.Pedido.Provision)
            .Include(p => p.Pedido.Provision.Destino)
            .Include(p => p.Proveedor)
            .FirstOrDefaultAsync(p => p.pedido_id == id_pedido && p.proveedor_id == id_proveedor);
        return pp;
    }

    // ---------------------------------------------------------
    // METODOS PARA PROCESO PEDIDO
    public async Task<ProcesoPedido> ObtenerUltimoProcesoNumero(int id)
    {
        var ultima = await _context.ProcesoPedido

        .Where(a => a.proceso_id == id)
        .OrderByDescending(a => a.num_proceso)
        .FirstOrDefaultAsync();
        return ultima;
    }
    public async Task<int> ObtenerUltimoProcesoPedidoId()
    {
        var ultima = await _context.ProcesoPedido
        .OrderByDescending(a => a.id)
        .Select(a => a.id)
        .FirstOrDefaultAsync();
        return ultima;
    }
    public async Task<ProcesoPedido> ObtenerProcesoPedidoPorPedidoId(int id)
    {
        var ultima = await _context.ProcesoPedido
            .Include(p => p.Pedido)
            .Include(p => p.Proceso)
            .Include(p => p.Proceso.TipoPedido)
            .Where(p => p.pedido_id == id)
            .FirstOrDefaultAsync();
        return ultima;
    }

    // ---------------------------------------------------------
    //METODOS PARA PROVISION_EXP
    public async Task<IEnumerable<ProvisionExp>> ObtenerProvisionExp()
    {
        return await _context.ProvisionExp
            .Include(p => p.Provision)
            .ToListAsync();
    }
    public async Task<ProvisionExp> ObtenerProvisionExpPorId(int id)
    {
        return await _context.ProvisionExp
            .Include(p => p.Provision)
            .FirstAsync(p => p.id == id);
    }
    public async Task<ProvisionExp> ObtenerUltimaProvisionExp()
    {
        var ultima = await _context.ProvisionExp
            .OrderByDescending(a => a.id)
            .Include(p => p.Provision)
            .FirstOrDefaultAsync();
        return ultima;
    }
    // Métodos para EstadoArticulo
    public async Task<IEnumerable<EstadoArticulo>> ObtenerEstadosArticulo()
    {
        return await _context.EstadoArticulo.ToListAsync();
    }

    public async Task<EstadoArticulo> ObtenerEstadoArticuloPorId(int id)
    {
        return await _context.EstadoArticulo.FindAsync(id);
    }



    public async Task<IEnumerable<PresupuestoPedido>> ObtenerPresupuestoPedidoPorIdPedidoProveedor(int id)
    {
        return await _context.PresupuestoPedidos
            .Include(p => p.PedidoProveedor)
            .Include(p => p.DetalleProvision.Articulo)
            .Include(p => p.DetalleProvision.UnidadMedida)
            .Where(p => p.pedido_proveedor_id == id)
            .ToListAsync();
    }

    public async Task<IEnumerable<PresupuestoPedido>> ObtenerPresupuestoPedidoPorPedidoId(int id)
    {
        return await _context.PresupuestoPedidos
            .Include(p => p.PedidoProveedor)
            .Include(p => p.DetalleProvision.Articulo)
            .Include(p => p.DetalleProvision.UnidadMedida)
            .Include(p => p.Proveedor)
            .Where(p => p.PedidoProveedor.pedido_id == id)
            .OrderBy(p => p.proveedor_id)
            .ToListAsync();
    }
    // FIN METODOS ESPECIFICOS
    // ---------------------------------------------------------

}

public class RepositorioArticulo : Repositorio<Articulo>
{
    public RepositorioArticulo(ContadSPContext context) : base(context)
    {
    }
}

public class RepositorioCategoria : Repositorio<Categoria>
{
    public RepositorioCategoria(ContadSPContext context) : base(context)
    {
    }
}

public class RepositorioDestino : Repositorio<Destino>
{
    public RepositorioDestino(ContadSPContext context) : base(context)
    {
    }
}

public class RepositorioDetalleProvision : Repositorio<DetalleProvision>
{
    public RepositorioDetalleProvision(ContadSPContext context) : base(context)
    {
    }
}

public class RepositorioPedido : Repositorio<Pedido>
{
    public RepositorioPedido(ContadSPContext context) : base(context)
    {
    }
}

public class RepositorioPedidoProveedor : Repositorio<PedidoProveedor>
{
    public RepositorioPedidoProveedor(ContadSPContext context) : base(context)
    {
    }
}
public class RepositorioProceso : Repositorio<Proceso>
{
    public RepositorioProceso(ContadSPContext context) : base(context)
    {
    }
}

public class RepositorioProcesoPedido : Repositorio<ProcesoPedido>
{
    public RepositorioProcesoPedido(ContadSPContext context) : base(context)
    {
    }
}

public class RepositorioProveedor : Repositorio<Proveedor>
{
    public RepositorioProveedor(ContadSPContext context) : base(context)
    {
    }
}

public class RepositorioProvision : Repositorio<Provision>
{
    public RepositorioProvision(ContadSPContext context) : base(context)
    {
    }
}

public class RepositorioSitFiscal : Repositorio<SitFiscal>
{
    public RepositorioSitFiscal(ContadSPContext context) : base(context)
    {
    }
}

public class RepositorioTipoPedido : Repositorio<TipoPedido>
{
    public RepositorioTipoPedido(ContadSPContext context) : base(context)
    {
    }
}
public class RepositorioUnidadMedida : Repositorio<UnidadMedida>
{
    public RepositorioUnidadMedida(ContadSPContext context) : base(context)
    {
    }
}

public class RepositorioUsuario : Repositorio<Usuario>
{
    public RepositorioUsuario(ContadSPContext context) : base(context)
    {
    }
}



