using Microsoft.EntityFrameworkCore;
using PanaderiaMj.Models;

namespace PanaderiaMj.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Recepciones> Recepciones { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        

        
    }
    
}
