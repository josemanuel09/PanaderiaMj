using Microsoft.EntityFrameworkCore;
using PanaderiaMj.Data;
using PanaderiaMj.Models;
using System.Linq.Expressions;

namespace PanaderiaMj.Service
{
    public class VentasService
    {
        private readonly ApplicationDbContext _contexto;
        public VentasService(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int VentaId)
        {
            return await _contexto.Ventas.AnyAsync(c => c.VentaId == VentaId);
        }
        public async Task<Ventas?> GetVentas(int id)
        {
            return await _contexto.Ventas.Include(c => c.DetalleVentas).FirstOrDefaultAsync(c => c.VentaId == id);
        }

        public async Task<bool> Insertar(Ventas ventas)
        {
            _contexto.Ventas.Add(ventas);
            int filasAfectadas = await _contexto.SaveChangesAsync();
            return filasAfectadas > 0;
        }
        public async Task<bool> Modificar(Ventas ventas)
        {
            var c = await _contexto.Ventas.FindAsync(ventas.VentaId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(ventas).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Ventas ventas)
        {
            if (!await Existe(ventas.VentaId))
                return await Insertar(ventas);
            else
                return await Modificar(ventas);
        }

        public async Task<bool> Eliminar(Ventas ventas)
        {
            var c = await _contexto.Clientes.FindAsync(ventas.VentaId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(ventas).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Ventas?> Buscar(int VentaId)
        {
            return await _contexto.Ventas
                .Where(c => c.VentaId == VentaId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Ventas>> Listar(Expression<Func<Ventas, bool>> Criterio)
        {
            return await _contexto.Ventas
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
