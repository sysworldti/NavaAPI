using Nava.Api.Model;
using System;
using System.Linq;

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
            if (entity.Items == null || !entity.Items.Any())
            {
                throw new Exception("Não foi cadastrado nenhum produto para a venda.");
            }
        }
    }    
}