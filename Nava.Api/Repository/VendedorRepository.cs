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
    public class VendedorRepository : IVendedorRepository
    {
        private readonly DatabaseContext context;

        /// <summary>
        /// Construtor do Vendedor Repository
        /// </summary>
        public VendedorRepository(DatabaseContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Cria um novo vendedor
        /// </summary>
        /// <param name="vendedor"></param>
        public Task Create(Vendedor vendedor)
        {
            context.Vendedores.Add(vendedor);
            context.SaveChangesAsync();
            return context.SaveChangesAsync();
        }

        /// <summary>
        /// Recupera um vendedor pelo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ValueTask<Vendedor> Get(long Id)
        {
            return context.Vendedores.FindAsync(Id);
        }

        /// <summary>
        /// Recupera todos os vendedores
        /// </summary>
        /// <returns></returns>
        public Task<List<Vendedor>> GetAll()
        {
            return context.Vendedores.ToListAsync();
        }

        /// <summary>
        /// Remove um vendedor
        /// </summary>
        /// <param name="venda"></param>
        public Task Remove(Vendedor venda)
        {
            context.Vendedores.Remove(venda);
            return context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um vendedor
        /// </summary>
        /// <param name="vendedor"></param>
        public Task Update(Vendedor vendedor)
        {
            context.Update(vendedor);
            return context.SaveChangesAsync();
        }
    }
}
