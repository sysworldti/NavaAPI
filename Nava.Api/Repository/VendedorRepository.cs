using Nava.Api.Model;

namespace Nava.Api.Repository
{
    /// <summary>
    /// VendedorRepository
    /// </summary>
    public class VendedorRepository : RepositoryBase<Vendedor>, IVendedorRepository
    {
        /// <summary>
        /// Construtor do Vendedor Repository
        /// </summary>
        public VendedorRepository(DatabaseContext context)
            : base(context, context.Vendedores)
        {
        }
    }
}
