using Microsoft.EntityFrameworkCore;
using Nava.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
