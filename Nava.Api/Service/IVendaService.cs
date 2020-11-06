using Nava.Api.Model;
using System.Threading.Tasks;

namespace Nava.Api.Service
{
    /// <summary>
    /// IVendaService
    /// </summary>
    public interface IVendaService
    {
        /// <summary>
        /// Serviço para informar que o pagamento da venda foi aprovado...
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task PagamentoAprovado(int Id);

        /// <summary>
        /// Serviço para informar que a venda foi cancelada...
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task CancelarVenda(int Id);

        /// <summary>
        /// Serviço para mudar o status da venda para enviado para a transportadora...
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task EnviarVendaParaTransportadora(int Id);

        /// <summary>
        /// Serviço para mudar o status da venda para entregue...
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task TransportadoraEntregarVenda(int Id);
    }
}
