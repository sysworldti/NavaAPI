namespace Nava.Api.Model
{
    /// <summary>
    /// Entidade do vendedor
    /// </summary>
    public class Vendedor : EntityBase
    {
        /// <summary>
        /// Nome do Vendedor
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Cpf do Vendedor
        /// </summary>
        public string CPF { get; set; }

        /// <summary>
        /// Email do Vendedor
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Telefone do Vendedor
        /// </summary>
        public string Telefone { get; set; }
    }
}
