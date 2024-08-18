namespace Application.Materials.Commands.CreateMaterial;

/// <summary>
/// Команда создания материала
/// </summary>
public record CreateMaterialCommand(CreateMaterialRequestDto dto)
    : IRequest<CreateMaterialResponseDto?>
{
    public required CreateMaterialRequestDto Dto { get; init; } = dto;
}