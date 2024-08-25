namespace Application.Materials.Queries.GetAllMaterials;

public record GetAllMaterialsRequestDto
{
    public int Skip { get; init; }
    public int Take { get; init; }
}
