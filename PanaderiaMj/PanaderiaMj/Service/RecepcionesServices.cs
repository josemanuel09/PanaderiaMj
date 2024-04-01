using Microsoft.EntityFrameworkCore;
using PanaderiaMj.DAL;
using PanaderiaMj.Models;
using System.Linq.Expressions;

namespace PanaderiaMj.Service
{
    public class RecepcionesServices
    {
        private readonly Contexto _contexto;

        public RecepcionesServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Insertar(Recepciones recepciones)
        {
            _contexto.Recepciones.Add(recepciones);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Recepciones recepciones)
        {
            var a = await _contexto.Recepciones.FindAsync(recepciones.RecepcionId);
            _contexto.Entry(a!).State = EntityState.Detached;
            _contexto.Entry(recepciones).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Existe(int RecepcionId)
        {
            return await _contexto.Recepciones
                .AnyAsync(a => a.RecepcionId == RecepcionId);
        }

        public async Task<bool> Guardar(Recepciones recepciones)
        {
            if (!await Existe(recepciones.RecepcionId))
                return await Insertar(recepciones);
            else
                return await Modificar(recepciones);
        }

        public async Task<bool> Eliminar(Recepciones recepciones)
        {
            var cantidad = await _contexto.Recepciones
                 .Where(a => a.RecepcionId == recepciones.RecepcionId)
                 .ExecuteDeleteAsync();
            return cantidad > 0;
        }


        public async Task<Recepciones?> Buscar(int recepcionId)
        {
            return await _contexto.Recepciones
                .Where(a => a.RecepcionId == recepcionId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Recepciones>> Listar(Expression<Func<Recepciones, bool>> Criterio)
        {
            return await _contexto.Recepciones
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
