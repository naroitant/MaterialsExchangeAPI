namespace Application.Materials.Queries.GetAllMaterials;

public record GetAllMaterialsResponseDto
{
    public required List<GetMaterialResponseDto> Dtos { get; init; }
}
