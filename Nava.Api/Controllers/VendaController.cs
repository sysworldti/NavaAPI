using Microsoft.AspNetCore.Mvc;
using Nava.Api.Model;
using Nava.Api.Repository;
using Nava.Api.Service;
using System;
using System.Threading.Tasks;

namespace Nava.Api.Controllers
{
    /// <summary>
    /// VendaController
    /// </summary>
    public class VendaController : ApiControllerBase<IVendaRepository, Venda>
    {       
        /// <summary>
        /// VendaController
        /// </summary>
        /// <param name="repository"></param>
        public VendaController(IVendaRepository repository)
            : base(repository)
        {            
        }

        /// <summary>
        /// Muda o status da venda para pagamento aprovado
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpPost("PagamentoAprovado/{Id}")]
        public async Task<IActionResult> PagamentoAprovado(int Id, [FromServices] IVendaService service)
        {
            try
            {
                await service.PagamentoAprovado(Id);
                return Ok("Pagamento aprovado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Permite que o usuário cancele uma venda
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpPost("CancelarVenda/{Id}")]
        public async Task<IActionResult> CancelarVenda(int Id, [FromServices] IVendaService service)
        {
            try
            {
                await service.CancelarVenda(Id);
                return Ok("Venda cancelada com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Permite que o usuário enviar venda para a transportadora
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpPost("EnviarVendaParaTransportadora/{Id}")]
        public async Task<IActionResult> EnviarVendaParaTransportadora(int Id, [FromServices] IVendaService service)
        {
            try
            {
                await service.EnviarVendaParaTransportadora(Id);
                return Ok("Pagamento enviado para a transportadora com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Permite que o usuário informe que a transportadora fez a entrega da mercadoria
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpPost("TransportadoraEntregarVenda/{Id}")]
        public async Task<IActionResult> TransportadoraEntregarVenda(int Id, [FromServices] IVendaService service)
        {
            try
            {
                await service.TransportadoraEntregarVenda(Id);
                return Ok("Produto entregue com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}