using System.Collections.Generic;
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
        /// Adiciona um novo registro na entidade
        /// </summary>
        /// <param name="entity"></param>
        Task Create(Entity entity);

        /// <summary>
        /// Atualiza a entidade passada
        /// </summary>
        /// <param name="entity"></param>
        Task Update(Entity entity);

        /// <summary>
        /// Remove a entidade do banco de dados
        /// </summary>
        /// <param name="entity"></param>
        Task Remove(Entity entity);

        /// <summary>
        /// Recupera uma entidade pelo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ValueTask<Entity> Get(int Id);

        /// <summary>
        /// Recupera todas as entidades do banco de dados
        /// </summary>
        /// <returns></returns>
        Task<List<Entity>> GetAll();

    }
}
