namespace Application.Sellers.Commands.UpdateMaterialsForSeller;

public record UpdateMaterialsForSellerRequestDto
{
    public required List<int> MaterialsId { get; init; } = [];
}
