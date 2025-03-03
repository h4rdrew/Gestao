using Gestao.Domain.Enums;

namespace Gestao.Domain;
public class FinancialTransaction
{
    public int Id { get; set; }
    /// <summary>
    /// Data de criação
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }
    /// <summary>
    /// Descrição da transação
    /// </summary>
    public string Description { get; set; } = string.Empty;
    /// <summary>
    /// Data de referência da transação
    /// </summary>
    public DateTimeOffset ReferenceDate { get; set; }
    /// <summary>
    /// Data de vencimento da transação
    /// </summary>
    public DateTimeOffset DueDate { get; set; }
    /// <summary>
    /// Valor da transação
    /// </summary>
    public decimal Amount { get; set; }
    /// <summary>
    /// Recorrência da transação
    /// </summary>
    public Recurrence Repeat { get; set; }
    /// <summary>
    /// Quantidade de vezes que a transação se repete
    /// </summary>
    public int RepeatTimes { get; set; }
    /// <summary>
    /// Valor da multa ou juros
    /// </summary>
    public decimal InterestPenalty { get; set; }
    /// <summary>
    /// Valor do desconto
    /// </summary>
    public decimal Discount { get; set; }
    /// <summary>
    /// Data de pagamento da transação
    /// </summary>
    public DateTimeOffset PaymentDate { get; set; }
    /// <summary>
    /// Valor pago
    /// </summary>
    public decimal AmoundPaid { get; set; }
    /// <summary>
    /// Observação
    /// </summary>
    public string? Observation { get; set; }
    /// <summary>
    /// Anexos
    /// </summary>
    public ICollection<DocumentAttachment>? DocumentAttachments { get; set; }
    /// <summary>
    /// Id da empresa
    /// </summary>
    public int? CompanyId { get; set; }
    /// <summary>
    /// Empresa
    /// </summary>
    public Company? Company { get; set; }
    /// <summary>
    /// Id da conta
    /// </summary>
    public int? AccountId { get; set; }
    /// <summary>
    /// Conta
    /// </summary>
    public Account? Account { get; set; }
    /// <summary>
    /// Id da categoria
    /// </summary>
    public int? CategoryId { get; set; }
    /// <summary>
    /// Categoria
    /// </summary>
    public Category? Category { get; set; }

}