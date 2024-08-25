namespace Application.Sellers.Commands.UpdateSeller;

/// <summary>
/// Команда обновления продавца
/// </summary>
public record UpdateSellerCommand(
    int id,
    UpdateSellerRequestDto dto)
    : IRequest<UpdateSellerResponseDto?>
{
    public required int Id { get; init; } = id;

    public required UpdateSellerRequestDto Dto { get; init; } = dto;
}