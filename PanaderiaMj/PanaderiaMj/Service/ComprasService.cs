using Microsoft.EntityFrameworkCore;
using PanaderiaMj.DAL;
using PanaderiaMj.Models;
using System.Linq.Expressions;

namespace PanaderiaMj.Service
{
    public class ComprasService
    {
        private readonly Contexto _contexto;
        public ComprasService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int CompraId)
        {
            return await _contexto.Compras.AnyAsync(c => c.CompraId == CompraId);
        }
        public async Task<Compras?> GetCompras(int id)
        {
            return await _contexto.Compras.Include(c => c.ComprasDetalle).FirstOrDefaultAsync(c => c.CompraId == id);
        }
        public async Task<bool> Insertar(Compras compras)
        {
            _contexto.Compras.Add(compras);
            int filasAfectadas = await _contexto.SaveChangesAsync();
            return filasAfectadas > 0;
        }
        public async Task<bool> Modificar(Compras compras)
        {
            var c = await _contexto.Compras.FindAsync(compras.CompraId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(compras).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Compras compras)
        {
            if (!await Existe(compras.CompraId))
                return await Insertar(compras);
            else
                return await Modificar(compras);
        }

        public async Task<bool> Eliminar(Compras compras)
        {
            var c = await _contexto.Compras.FindAsync(compras.CompraId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(compras).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Compras?> Buscar(int CompraId)
        {
            return await _contexto.Compras
                .Where(c => c.CompraId == CompraId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Compras>> Listar(Expression<Func<Compras, bool>> Criterio)
        {
            return await _contexto.Compras
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
