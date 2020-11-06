using Nava.Api.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int Id { get; set; }

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
        public int VendedorId { get; set; }

        /// <summary>
        /// Vendedor associado a venda
        /// </summary>
        [ForeignKey("VendedorId")]
        public Vendedor Vendedor { get; set; }

        /// <summary>
        /// Itens da venda
        /// </summary>
        public List<VendaItem> Items { get; set; }
    }
}
