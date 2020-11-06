using Nava.Api.Model;

namespace Nava.Api.Repository
{
    /// <summary>
    /// Repositorio de vendas
    /// </summary>
    public class VendaRepository : RepositoryBase<Venda>, IVendaRepository
    {
        /// <summary>
        /// Construtor do Venda Repository
        /// </summary>
        public VendaRepository(DatabaseContext context)
            : base(context, context.Vendas)
        {
        }

        /// <summary>
        /// Força a venda iniciar com o status de aguardando pagamento.
        /// </summary>
        /// <param name="entity"></param>
        protected override void DoBeforeCreate(Venda entity)
        {
            entity.Status = Enums.StatusVenda.AguardandoPagamento;
        }
    }    
}