using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PanaderiaMj.Models;

namespace PanaderiaMj.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Insumos> Insumos { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Recepciones> Recepciones { get; set; }
    }
}
