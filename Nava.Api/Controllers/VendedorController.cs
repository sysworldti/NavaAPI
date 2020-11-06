using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nava.Api.Model;
using Nava.Api.Repository;
using System;
using System.Threading.Tasks;

namespace Nava.Api.Controllers
{
    /// <summary>
    /// VendedorController
    /// </summary>
    public class VendedorController : ApiControllerBase
    {
        private readonly IVendedorRepository repository;

        /// <summary>
        /// vendedorController
        /// </summary>
        /// <param name="repository"></param>
        public VendedorController(IVendedorRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Recupera um vendedor pelo Id da entidade
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
        /// Recupera todos os vendedores
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
        /// Cria um novo vendedor no sistema
        /// </summary>
        /// <param name="vendedor"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Vendedor vendedor)
        {
            try
            {
                await repository.Create(vendedor);
                return CreatedAtAction("Create", vendedor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Atualiza um vendedor
        /// </summary>
        /// <param name="vendedor"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] Vendedor vendedor)
        {
            try
            {
                await repository.Update(vendedor);
                return Ok(vendedor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Remove um vendedor pelo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("Remove/{Id:long}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Remove(long Id)
        {
            try
            {
                var vendedor = await repository.Get(Id);
                if (vendedor == null)
                {
                    throw new Exception("Vendedor não encontrada!");
                }

                await repository.Remove(vendedor);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}