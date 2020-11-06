using Nava.Api.Model;
using Nava.Api.Repository;

namespace Nava.Api.Controllers
{
    /// <summary>
    /// VendedorController
    /// </summary>
    public class VendedorController : ApiControllerBase<IVendedorRepository, Vendedor>
    {
        private readonly IVendedorRepository repository;

        /// <summary>
        /// vendedorController
        /// </summary>
        /// <param name="repository"></param>
        public VendedorController(IVendedorRepository repository)
            : base(repository)
        {            
        }
    }
}