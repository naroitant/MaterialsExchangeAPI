namespace Application.Materials.Queries.GetAllMaterials;

/// <summary>
/// Запрос на получение всех материалов
/// </summary>
public record GetAllMaterialsQuery(GetAllMaterialsRequestDto dto)
    : IRequest<GetAllMaterialsResponseDto>
{
    public required GetAllMaterialsRequestDto Dto { get; init; } = dto;
}