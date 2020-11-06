using Nava.Api.Enums;

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
        public long Id { get; set; }

        /// <summary>
        /// Número da venda
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Status atual da venda
        /// </summary>
        public StatusVenda Status { get; set; }
    }
}
