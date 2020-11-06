using Nava.Api.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nava.Api.Model
{
    /// <summary>
    /// Venda
    /// </summary>
    public class Venda
    {
        /// <summary>
        /// Id da venda
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Data de realização da venda
        /// </summary>
        public DateTime DataVenda { get; set; }

        /// <summary>
        /// Número da venda
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Status atual da venda
        /// </summary>
        public StatusVenda Status { get; set; }

        /// <summary>
        /// Vendedor que está realizando a Venda
        /// </summary>
        public Vendedor Vendedor { get; set; }

        /// <summary>
        /// Itens da venda
        /// </summary>
        public IQueryable<VendaItem> Items { get; set; }
    }
}
