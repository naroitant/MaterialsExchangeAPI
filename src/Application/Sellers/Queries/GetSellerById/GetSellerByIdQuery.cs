namespace Application.Sellers.Queries.GetSellerById;

/// <summary>
/// Запрос на получение продавца по id
/// </summary>
public record GetSellerByIdQuery(int id)
    : IRequest<GetSellerResponseDto?>
{
    public required int Id { get; init; } = id;
}