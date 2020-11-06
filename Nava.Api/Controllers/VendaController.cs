using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nava.Api.Model;
using Nava.Api.Repository;
using System;
using System.Threading.Tasks;

namespace Nava.Api.Controllers
{
    /// <summary>
    /// VendaController
    /// </summary>
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IVendaRepository repository;

        /// <summary>
        /// VendaController
        /// </summary>
        /// <param name="repository"></param>
        public VendaController(IVendaRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Recupera uma venda pelo Id da entidade
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
        /// Recupera todas as Vendas
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
        /// Cria uma nova venda no sistema
        /// </summary>
        /// <param name="venda"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Venda venda)
        {
            try
            {
                await repository.Create(venda);
                return CreatedAtAction("Create", venda);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Atualiza uma venda
        /// </summary>
        /// <param name="venda"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] Venda venda)
        {
            try
            {
                await repository.Update(venda);
                return Ok(venda);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Remove uma venda pelo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("Remove/{Id:long}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Remove(long Id)
        {
            try
            {
                var venda = await repository.Get(Id);
                if (venda == null)
                {
                    throw new Exception("Venda não encontrada!");
                }

                await repository.Remove(venda);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Muda o status da venda para pagamento aprovado
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost("PagamentoAprovado/{Id:long}")]
        public async Task<IActionResult> PagamentoAprovado(long Id)
        {
            try
            {
                var venda = await repository.Get(Id);
                if (venda == null)
                {
                    throw new Exception("Venda não encontrada!");
                }

                venda.Status = Enums.StatusVenda.PagamentoAprovado;
                repository.Update(venda);
                return Ok("Pagamento aprovado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}