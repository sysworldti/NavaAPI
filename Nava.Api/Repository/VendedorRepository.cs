using Nava.Api.Model;

namespace Nava.Api.Repository
{
    /// <summary>
    /// VendedorRepository
    /// </summary>
    public class VendedorRepository : RepositoryBase<Vendedor>, IVendedorRepository
    {
        private readonly DatabaseContext context;

        /// <summary>
        /// Construtor do Vendedor Repository
        /// </summary>
        public VendedorRepository(DatabaseContext context)
            : base(context, context.Vendedores)
        {
            this.context = context;
        }
    }
}
