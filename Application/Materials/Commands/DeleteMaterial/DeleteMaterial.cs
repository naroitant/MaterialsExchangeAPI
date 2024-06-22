using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Material.Commands.DeleteMaterialCommand;

/// <summary>
/// Команда удаления материала
/// </summary>
public class DeleteMaterial : IRequest<MaterialDto>
{
    /// <summary>
    /// Уникальный идентификатор материала
    /// </summary>
    public required int Id { get; set; }
}

public class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterial, MaterialDto>
{
    private readonly IMaterialRepository _materialRepository;

    public DeleteMaterialCommandHandler(IMaterialRepository materialRepository)
    {
        _materialRepository = materialRepository;
    }

    public async Task<MaterialDto?> Handle(DeleteMaterial command, CancellationToken token)
    {
        int id = command.Id;
        var material = await _materialRepository.DeleteAsync(id);

        if (material == null)
        {
            return null;
        }

        MaterialDto materialDto = material.ToMaterialDto();
        return materialDto;
    }
}
