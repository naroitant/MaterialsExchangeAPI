namespace Application.Materials.Commands.DeleteMaterial;

/// <summary>
/// Команда удаления материала
/// </summary>
public record DeleteMaterialCommand(DeleteMaterialRequestDto dto)
    : IRequest<bool>
{
    public required DeleteMaterialRequestDto Dto { get; init; } = dto;
}