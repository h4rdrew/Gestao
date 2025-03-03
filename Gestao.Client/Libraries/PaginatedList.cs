namespace Gestao.Client.Libraries;

public class PaginatedList<T>
{
    public PaginatedList(List<T> items, int pageIndex, int totalPages)
    {
        Items = items;
        PageIndex = pageIndex;
        TotalPages = totalPages;
    }

    /// <summary>
    /// Lista de itens
    /// </summary>
    public List<T> Items { get; } = [];
    /// <summary>
    /// Índice da página
    /// </summary>
    public int PageIndex { get; }
    /// <summary>
    /// Total de páginas
    /// </summary>
    public int TotalPages { get; }
    /// <summary>
    /// Checa se tem próxima página
    /// </summary>
    public bool HasNextPage => PageIndex < TotalPages;
    /// <summary>
    /// Checa se tem página anterior
    /// </summary>
    public bool HasPreviousPage => PageIndex > 1;
}
