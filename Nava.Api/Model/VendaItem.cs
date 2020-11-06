using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nava.Api.Model
{
    /// <summary>
    /// Itens da Venda
    /// </summary>
    public class VendaItem
    {
        /// <summary>
        /// Id da tabela de item da venda
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do Produto que será vendido
        /// </summary>        
        public string NomeProduto { get; set; }

        /// <summary>
        /// Quantidade de produto(s) vendido(s)
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Id da Venda
        /// </summary>
        public int VendaId { get; set; }

        /// <summary>
        /// Venda em que o item está participando
        /// </summary>
        [ForeignKey("VendaId")]
        public Venda Venda { get; set; }
    }
}
