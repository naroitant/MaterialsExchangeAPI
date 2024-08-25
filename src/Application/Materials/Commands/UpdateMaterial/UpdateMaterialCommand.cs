namespace Application.Materials.Commands.UpdateMaterial;

/// <summary>
/// Команда обновления информации о материале
/// </summary>
public record UpdateMaterialCommand(
    int id,
    UpdateMaterialRequestDto dto)
    : IRequest<UpdateMaterialResponseDto?>
{
    public required int Id { get; init; } = id;
    public required UpdateMaterialRequestDto Dto { get; init; } = dto;
}