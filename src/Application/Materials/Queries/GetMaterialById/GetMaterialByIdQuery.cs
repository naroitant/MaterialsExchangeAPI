namespace Application.Materials.Queries.GetMaterialById;

/// <summary>
/// Запрос на получение материала по id
/// </summary>
public record GetMaterialByIdQuery(GetMaterialByIdRequestDto dto)
    : IRequest<GetMaterialResponseDto?>
{
    public required GetMaterialByIdRequestDto Dto { get; init; } = dto;
}