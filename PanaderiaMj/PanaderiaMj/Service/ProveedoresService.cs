using Microsoft.EntityFrameworkCore;
using PanaderiaMj.DAL;
using PanaderiaMj.Models;
using System.Linq.Expressions;

namespace PanaderiaMj.Service
{
    public class ProveedoresService
    {
        private readonly Contexto _contexto;
        public ProveedoresService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int ProveedorId)
        {
            return await _contexto.Proveedores.AnyAsync(c => c.ProveedorId == ProveedorId);
        }

        public async Task<bool> Insertar(Proveedores proveedores)
        {
            _contexto.Proveedores.Add(proveedores);
            int filasAfectadas = await _contexto.SaveChangesAsync();
            return filasAfectadas > 0;
        }
        public async Task<bool> Modificar(Proveedores proveedores)
        {
            var c = await _contexto.Proveedores.FindAsync(proveedores.ProveedorId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(proveedores).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Proveedores proveedores)
        {
            if (!await Existe(proveedores.ProveedorId))
                return await Insertar(proveedores);
            else
                return await Modificar(proveedores);
        }

        public async Task<bool> Eliminar(Proveedores proveedores)
        {
            var c = await _contexto.Clientes.FindAsync(proveedores.ProveedorId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(proveedores).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Proveedores?> Buscar(int ProveedorId)
        {
            return await _contexto.Proveedores
                .Where(c => c.ProveedorId == ProveedorId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Proveedores>> Listar(Expression<Func<Proveedores, bool>> Criterio)
        {
            return await _contexto.Proveedores
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
