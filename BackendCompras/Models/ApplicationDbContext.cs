using Microsoft.EntityFrameworkCore;


namespace BackendCompras.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Proveedor> proveedor { get; set;}
        public DbSet<department> department { get; set;}

        public DbSet<UnidadMedidas> unidadMedida { get; set;}
        public DbSet<Articulo> articulo { get; set;}
        public DbSet<OrdenesCompra> ordenesCompra { get; set;}  
       
    }
}
