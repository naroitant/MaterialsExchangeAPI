namespace Application.Sellers.Queries.GetSellerById;

/// <summary>
/// Запрос на получение продавца по id
/// </summary>
public record GetSellerByIdQuery(GetSellerByIdRequestDto dto)
    : IRequest<GetSellerResponseDto?>
{
    public required GetSellerByIdRequestDto Dto { get; init; } = dto;
}