using Nava.Api.Model;
using Nava.Api.Repository;
using System;
using System.Threading.Tasks;

namespace Nava.Api.Service
{
    /// <summary>
    /// VendaService
    /// </summary>
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository repository;

        /// <summary>
        /// VendaService
        /// </summary>
        /// <param name="repository"></param>
        public VendaService(IVendaRepository repository)
        {
            this.repository = repository;
        }

        private async Task ExecutaProcesamento(int Id, Action<Venda> action)
        {
            var venda = await repository.Get(Id);
            if (venda == null)
            {
                throw new Exception("Venda não encontrada!");
            }
            action(venda);
            await repository.Update(venda);
        }

        /// <summary>
        /// Muda o status da venda para pagamento aprovado...
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task PagamentoAprovado(int Id)
        {
            await ExecutaProcesamento(Id, (venda) =>
            {
                venda.Status = Enums.StatusVenda.PagamentoAprovado;
            });
        }

        /// <summary>
        /// Muda o status da venda para cancelada
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task CancelarVenda(int Id)
        {
            await ExecutaProcesamento(Id, (venda) =>
            {
                if (venda.Status != Enums.StatusVenda.AguardandoPagamento && venda.Status != Enums.StatusVenda.PagamentoAprovado)
                    throw new Exception("Não é permitido cancelar a venda.");
                venda.Status = Enums.StatusVenda.Cancelado;
            });
        }

        /// <summary>
        /// Muda o status da venda para enviado para transportadora 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task EnviarVendaParaTransportadora(int Id)
        {
            await ExecutaProcesamento(Id, (venda) =>
            {
                if (venda.Status != Enums.StatusVenda.PagamentoAprovado)
                    throw new Exception("Venda não pode ser enviada para a transportadora, pois a venda ainda não está aprovada e/ou está cancelada ou entregue...");
                venda.Status = Enums.StatusVenda.EnvioTransportadora;
            });
        }

        /// <summary>
        /// Muda o status da venda para entregue ao consumidor final
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task TransportadoraEntregarVenda(int Id)
        {
            await ExecutaProcesamento(Id, (venda) =>
            {
                if (venda.Status != Enums.StatusVenda.EnvioTransportadora)
                    throw new Exception("Venda ainda não encontra-se com a transportadora...");
                venda.Status = Enums.StatusVenda.Entregue;
            });
        }
    }
}
