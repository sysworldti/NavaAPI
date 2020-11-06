using System.ComponentModel.DataAnnotations;

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
        public long Id { get; set; }

        /// <summary>
        /// Nome do Produto que será vendido
        /// </summary>        
        public string NomeProduto { get; set; }

        /// <summary>
        /// Quantidade de produto(s) vendido(s)
        /// </summary>
        public int Quantidade { get; set; }
    }
}
