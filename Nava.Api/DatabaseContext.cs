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
        /// DbSet de Vendas
        /// </summary>
        public DbSet<Venda> Vendas { get; set; }
    }
}
