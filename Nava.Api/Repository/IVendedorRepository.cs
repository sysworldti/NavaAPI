using Nava.Api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nava.Api.Repository
{
    /// <summary>
    /// IVendedorRepository
    /// </summary>
    public interface IVendedorRepository
    {
        /// <summary>
        /// Adiciona um novo vendedor
        /// </summary>
        /// <param name="vendedor"></param>
        Task Create(Vendedor vendedor);

        /// <summary>
        /// Atualiza um Vendedor existente
        /// </summary>
        /// <param name="vendedor"></param>
        Task Update(Vendedor vendedor);

        /// <summary>
        /// Remove um determinado vendedor
        /// </summary>
        /// <param name="vendedor"></param>
        Task Remove(Vendedor vendedor);

        /// <summary>
        /// Recupera um vendedor pelo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ValueTask<Vendedor> Get(long Id);

        /// <summary>
        /// Recupera uma lista de vendedores
        /// </summary>
        /// <returns></returns>
        Task<List<Vendedor>> GetAll();
    }
}