namespace Application.Core.Responses;

public sealed class PaginatedResponse<T>(
	IReadOnlyList<T> items,
	int totalCount,
	int? pageNumber,
	int? pageSize)
{

	// ===== Data =====
	public IReadOnlyList<T> Items { get; } = items;

	// ===== Paging Info =====
	public int PageNumber { get; } = (pageNumber == null || pageNumber.Value == 0) ? 1 : pageNumber.Value;
	public int PageSize { get; } = pageSize == null || pageSize.Value == 0 ? 10 : pageSize.Value;

	public int TotalCount { get; } = totalCount;

	public int TotalPages { get; } = pageSize <= 0 ? 1 : (int)Math.Ceiling(totalCount / (double)(pageSize ?? totalCount));

	// ===== Navigation helpers =====
	public bool HasPrevious => PageNumber > 1;
	public bool HasNext => PageNumber < TotalPages;
}

