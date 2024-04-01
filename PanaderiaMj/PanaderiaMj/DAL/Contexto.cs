using Microsoft.EntityFrameworkCore;
using PanaderiaMj.Models;

namespace PanaderiaMj.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Insumos> Insumos { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Recepciones> Recepciones { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        

        
    }
    
}
