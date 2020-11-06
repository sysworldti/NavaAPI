using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nava.Api.Repository
{
    /// <summary>
    /// IRepositoryBase
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    public interface IRepositoryBase<Entity>
    {
        /// <summary>
        /// Adiciona uma nova venda
        /// </summary>
        /// <param name="entity"></param>
        Task Create(Entity entity);

        /// <summary>
        /// Atualiza uma Venda existente
        /// </summary>
        /// <param name="entity"></param>
        Task Update(Entity entity);

        /// <summary>
        /// Remove uma determinada Venda
        /// </summary>
        /// <param name="entity"></param>
        Task Remove(Entity entity);

        /// <summary>
        /// Recupera uma venda pelo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ValueTask<Entity> Get(long Id);

        /// <summary>
        /// Recupera uma lista de  vendas
        /// </summary>
        /// <returns></returns>
        Task<List<Entity>> GetAll();

    }
}
