using Microsoft.EntityFrameworkCore;
using Nava.Api.Model;

namespace Nava.Api
{
    /// <summary>
    /// DatabaseContext
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// DatabaseContext
        /// </summary>
        /// <param name="options"></param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
          : base(options)
        {
        }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Venda>().HasOne(p => p.Vendedor);
            modelBuilder.Entity<Venda>().HasMany(p => p.Items);
        }

        /// <summary>
        /// DbSet de Vendas
        /// </summary>
        public DbSet<Venda> Vendas { get; set; }

        /// <summary>
        /// DbSet de Vendedores
        /// </summary>
        public DbSet<Vendedor> Vendedores { get; set; }

        /// <summary>
        /// DbSet de Itens da Venda
        /// </summary>
        public DbSet<VendaItem> VendaItens { get; set; }
    }
}
