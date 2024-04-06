using Microsoft.EntityFrameworkCore;
using PanaderiaMj.Data;
using PanaderiaMj.Models;
using System.Linq.Expressions;

namespace PanaderiaMj.Service
{
    public class InsumosService
    {
        private readonly ApplicationDbContext _contexto;

        public InsumosService(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Insertar(Insumos insumos)
        {
            _contexto.Insumos.Add(insumos);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Insumos insumos)
        {
            var a = await _contexto.Insumos.FindAsync(insumos.InsumoId);
            _contexto.Entry(a!).State = EntityState.Detached;
            _contexto.Entry(insumos).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Existe(int InsumoId)
        {
            return await _contexto.Insumos
                .AnyAsync(a => a.InsumoId == InsumoId);
        }

        public async Task<bool> Guardar(Insumos insumos)
        {
            if (!await Existe(insumos.InsumoId))
                return await Insertar(insumos);
            else
                return await Modificar(insumos);
        }

        public async Task<bool> Eliminar(Insumos insumos)
        {
            var cantidad = await _contexto.Insumos
                 .Where(a => a.InsumoId == insumos.InsumoId)
                 .ExecuteDeleteAsync();
            return cantidad > 0;
        }


        public async Task<Insumos?> Buscar(int insumoId)
        {
            return await _contexto.Insumos
                .Where(a => a.InsumoId == insumoId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Insumos>> Listar(Expression<Func<Insumos, bool>> Criterio)
        {
            return await _contexto.Insumos
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}