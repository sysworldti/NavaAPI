using Microsoft.EntityFrameworkCore;
using Nava.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nava.Api.Repository
{
    /// <summary>
    /// Repositorio de vendas
    /// </summary>
    public class VendaRepository : RepositoryBase<Venda>, IVendaRepository
    {
        private readonly DatabaseContext context;


        /// <summary>
        /// Construtor do Venda Repository
        /// </summary>
        public VendaRepository(DatabaseContext context)
            : base(context, context.Vendas)
        {
            this.context = context;
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

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public override Task<Venda> Get(int Id)
        {
            return context.Vendas.Include(p => p.Items).Where(p => p.Id == Id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public override Task<List<Venda>> GetAll()
        {
            return context.Vendas.Include(x => x.Items).ToListAsync();
        }
    }    
}