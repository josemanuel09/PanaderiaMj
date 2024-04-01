using Microsoft.EntityFrameworkCore;
using PanaderiaMj.DAL;
using PanaderiaMj.Models;
using System.Linq.Expressions;

namespace PanaderiaMj.Service
{
    public class ClientesServices
    {
        private readonly Contexto _contexto;

        public ClientesServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Insertar(Clientes cliente)
        {
            _contexto.Clientes.Add(cliente);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Clientes cliente)
        {
            var a = await _contexto.Clientes.FindAsync(cliente.ClienteId);
            _contexto.Entry(a!).State = EntityState.Detached;
            _contexto.Entry(cliente).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Existe(int ClienteId)
        {
            return await _contexto.Clientes
                .AnyAsync(a => a.ClienteId == ClienteId);
        }

        public async Task<bool> Guardar(Clientes clientes)
        {
            if (!await Existe(clientes.ClienteId))
                return await Insertar(clientes);
            else
                return await Modificar(clientes);
        }

        public async Task<bool> Eliminar(Clientes clientes)
        {
            var cantidad = await _contexto.Clientes
                 .Where(a => a.ClienteId == clientes.ClienteId)
                 .ExecuteDeleteAsync();
            return cantidad > 0;
        }


        public async Task<Clientes?> Buscar(int clienteId)
        {
            return await _contexto.Clientes
                .Where(a => a.ClienteId == clienteId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> Criterio)
        {
            return await _contexto.Clientes
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
