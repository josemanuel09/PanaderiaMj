using Microsoft.EntityFrameworkCore;
using PanaderiaMj.DAL;
using PanaderiaMj.Models;
using System.Linq.Expressions;

namespace PanaderiaMj.Service
{
    public class ProductosServices
    {
        private readonly Contexto _contexto;
        public ProductosService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int ProductoId)
        {
            return await _contexto.Productos.AnyAsync(c => c.ProductoId == ProductoId);
        }
        public async Task<Productos?> GetProductos(int id)
        {
            return await _contexto.Productos.Include(c => c.ProductosDetalle).FirstOrDefaultAsync(c => c.ProductoId == id);
        }

        public async Task<bool> Insertar(Productos productos)
        {
            _contexto.Productos.Add(productos);
            int filasAfectadas = await _contexto.SaveChangesAsync();
            return filasAfectadas > 0;
        }
        public async Task<bool> Modificar(Productos productos)
        {
            var c = await _contexto.Productos.FindAsync(productos.ProductoId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(productos).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Productos productos)
        {
            if (!await Existe(productos.ProductoId))
                return await Insertar(productos);
            else
                return await Modificar(productos);
        }

        public async Task<bool> Eliminar(Productos productos)
        {
            var c = await _contexto.Productos.FindAsync(productos.ProductoId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(productos).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Productos?> Buscar(int ProductoId)
        {
            return await _contexto.Productos
                .Where(c => c.ProductoId == ProductoId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Productos>> Listar(Expression<Func<Productos, bool>> Criterio)
        {
            return await _contexto.Productos
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
