namespace Nava.Api.Enums
{
    /// <summary>
    /// Define os status dade venda
    /// </summary>
    public enum StatusVenda
    {
        /// <summary>
        /// Aguardando pagamento
        /// </summary>
        AguardandoPagamento = 10,

        /// <summary>
        /// Pagamento Aprovado
        /// </summary>
        PagamentoAprovado = 20,

        /// <summary>
        /// Cancelada
        /// </summary>
        Cancelado = 30,

        /// <summary>
        /// Enviado para Transportadora
        /// </summary>
        EnvioTransportadora = 40,

        /// <summary>
        /// Entregue
        /// </summary>
        Entregue = 50
    }
}