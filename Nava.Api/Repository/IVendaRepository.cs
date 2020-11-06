using Nava.Api.Enums;
using Nava.Api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nava.Api.Repository
{
    /// <summary>
    /// Interface do repositorio de vendas
    /// </summary>
    public interface IVendaRepository
    {
        /// <summary>
        /// Adiciona uma nova venda
        /// </summary>
        /// <param name="venda"></param>
        Task Create(Venda venda);

        /// <summary>
        /// Atualiza uma Venda existente
        /// </summary>
        /// <param name="venda"></param>
        Task Update(Venda venda);

        /// <summary>
        /// Remove uma determinada Venda
        /// </summary>
        /// <param name="venda"></param>
        Task Remove(Venda venda);

        /// <summary>
        /// Recupera uma venda pelo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ValueTask<Venda> Get(long Id);

        /// <summary>
        /// Recupera uma lista de  vendas
        /// </summary>
        /// <returns></returns>
        Task<List<Venda>> GetAll();
    }
}