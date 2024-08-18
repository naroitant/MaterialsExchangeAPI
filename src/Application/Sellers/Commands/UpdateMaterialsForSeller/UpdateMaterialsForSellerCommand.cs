namespace Application.Sellers.Commands.UpdateMaterialsForSeller;

public record UpdateMaterialsForSellerCommand(
    int id,
    UpdateMaterialsForSellerRequestDto dto)
    : IRequest<UpdateMaterialsForSellerResponseDto?>
{
    public int Id { get; init; } = id;

    public UpdateMaterialsForSellerRequestDto Dto { get; init; } = dto;
}