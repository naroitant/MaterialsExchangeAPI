using Application.Materials.Queries;

namespace Application.Sellers.Commands.UpdateMaterialsForSeller;

public record UpdateMaterialsForSellerResponseDto
{
    public required int Id { get; init; }
    public required List<GetMaterialResponseDto> Dtos { get; init; } = [];
}
