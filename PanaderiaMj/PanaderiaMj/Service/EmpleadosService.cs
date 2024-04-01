using Microsoft.EntityFrameworkCore;
using PanaderiaMj.DAL;
using PanaderiaMj.Models;
using System.Linq.Expressions;

namespace PanaderiaMj.Service
{
    public class EmpleadosService
    {
        private readonly Contexto _contexto;
        public EmpleadosService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int EmpleadoId)
        {
            return await _contexto.Empleados.AnyAsync(c => c.EmpleadoId == EmpleadoId);
        }
        public async Task<bool> ValidarNombre(string nombre)
        {
            var EmpleadoExistente = await _contexto.Empleados.AnyAsync(c => c.Nombre == nombre);
            return EmpleadoExistente;
        }
        public async Task<bool> Insertar(Empleados empleados)
        {
            _contexto.Empleados.Add(empleados);
            int filasAfectadas = await _contexto.SaveChangesAsync();
            return filasAfectadas > 0;
        }
        public async Task<bool> Modificar(Empleados empleados)
        {
            var c = await _contexto.Empleados.FindAsync(empleados.EmpleadoId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(empleados).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Empleados empleados)
        {
            if (!await Existe(empleados.EmpleadoId))
                return await Insertar(empleados);
            else
                return await Modificar(empleados);
        }

        public async Task<bool> Eliminar(Empleados empleados)
        {
            var c = await _contexto.Empleados.FindAsync(empleados.EmpleadoId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(empleados).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Empleados?> Buscar(int EmpleadoId)
        {
            return await _contexto.Empleados
                .Where(c => c.EmpleadoId == EmpleadoId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Empleados>> Listar(Expression<Func<Empleados, bool>> Criterio)
        {
            return await _contexto.Empleados
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
