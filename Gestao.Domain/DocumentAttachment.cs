namespace Gestao.Domain
{
    public class DocumentAttachment
    {
        public int Id { get; set; }
        /// <summary>
        /// Local do arquivo
        /// </summary>
        public string Path { get; set; } = null!;
        /// <summary>
        /// Id da transação financeira
        /// </summary>
        public int? FinancialTransactionId { get; set; }
        /// <summary>
        /// Transação financeira
        /// </summary>
        public FinancialTransaction? FinancialTransaction { get; set; }
    }
}