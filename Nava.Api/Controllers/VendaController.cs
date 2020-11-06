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
    public class VendaController : ApiControllerBase<IVendaRepository, Venda>
    {
        private readonly IVendaRepository repository;

        /// <summary>
        /// VendaController
        /// </summary>
        /// <param name="repository"></param>
        public VendaController(IVendaRepository repository)
            : base(repository)
        {
            this.repository = repository;
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
                await repository.Update(venda);
                return Ok("Pagamento aprovado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}