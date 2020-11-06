using Microsoft.EntityFrameworkCore;
using Nava.Api.Enums;
using Nava.Api.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nava.Api.Repository
{
    /// <summary>
    /// Repositorio de vendas
    /// </summary>
    public class VendaRepository : IVendaRepository
    {
        private readonly DatabaseContext context;

        /// <summary>
        /// Construtor do Venda Repository
        /// </summary>
        public VendaRepository(DatabaseContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Cria uma nova venda
        /// </summary>
        /// <param name="venda"></param>
        public Task Create(Venda venda)
        {
            venda.Status = StatusVenda.AguardandoPagamento;
            context.Vendas.Add(venda);
            context.SaveChangesAsync();
            return context.SaveChangesAsync();
        }

        /// <summary>
        /// Recupera uma venda pelo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ValueTask<Venda> Get(long Id)
        {
            return context.Vendas.FindAsync(Id);
        }

        /// <summary>
        /// Recupera todas as vendas
        /// </summary>
        /// <returns></returns>
        public Task<List<Venda>> GetAll()
        {
            return context.Vendas.ToListAsync();
        }

        /// <summary>
        /// Remove uma venda
        /// </summary>
        /// <param name="venda"></param>
        public Task Remove(Venda venda)
        {            
            context.Vendas.Remove(venda);
            return context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza uma venda
        /// </summary>
        /// <param name="venda"></param>
        public Task Update(Venda venda)
        {
            context.Update(venda);
            return context.SaveChangesAsync();
        }
    }
}