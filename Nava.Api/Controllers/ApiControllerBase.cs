using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nava.Api.Repository;
using System;
using System.Threading.Tasks;

namespace Nava.Api.Controllers
{
    /// <summary>
    /// ApiControllerBase
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase<IRepository, Entity> : ControllerBase
        where IRepository : IRepositoryBase<Entity>
    {
        private readonly IRepository repository;

        /// <summary>
        /// ApiControllerBase
        /// </summary>
        /// <param name="repository"></param>
        public ApiControllerBase(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Recupera um registro no banco de dados pelo seu Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("Get/{Id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(long Id)
        {
            try
            {
                return Ok(await repository.Get(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Recupera recupera todos os registros do banco de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await Task.Factory.StartNew(() =>
                {
                    return repository.GetAll();
                }));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Cria um novo registro no banco de dados
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Entity entity)
        {
            try
            {
                await repository.Create(entity);
                return CreatedAtAction("Create", entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Atualiza o registro corrente no banco de dados
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] Entity entity)
        {
            try
            {
                await repository.Update(entity);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Remove o registro do bando de dados pelo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("Remove/{Id:long}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Remove(long Id)
        {
            try
            {
                var entity = await repository.Get(Id);
                if (entity == null)
                {
                    throw new Exception($"Registro não foi encontrado pelo Id: {Id}!");
                }

                await repository.Remove(entity);
                return Ok("Registro removido com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}