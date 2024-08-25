namespace Application.Sellers.Queries.GetAllSellers;

/// <summary>
/// Запрос на получение всех продавцов
/// </summary>
public record GetAllSellersQuery(GetAllSellersRequestDto dto)
    : IRequest<GetSellersResponseDto>
{
    public required GetAllSellersRequestDto Dto { get; init; } = dto;
}