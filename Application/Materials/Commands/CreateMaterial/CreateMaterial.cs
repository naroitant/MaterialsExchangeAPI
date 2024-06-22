using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Material.Commands.CreateMaterialCommand;

/// <summary>
/// Команда создания материала
/// </summary>
public class CreateMaterial : IRequest<MaterialDto>
{
    /// <summary>
    /// Название материала
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Стоимость материала
    /// </summary>
    public required decimal Price { get; set; }

    /// <summary>
    /// Уникальный идентификатор продавца
    /// </summary>
    public required int SellerId { get; set; }
}

public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterial, MaterialDto>
{
    private readonly IMaterialRepository _materialRepository;

    public CreateMaterialCommandHandler(IMaterialRepository materialRepository)
    {
        _materialRepository = materialRepository;
    }

    public async Task<MaterialDto> Handle(CreateMaterial command, CancellationToken token)
    {
        MaterialDto materialDto = new MaterialDto();
        materialDto.Name = command.Name;
        materialDto.Price = command.Price;
        materialDto.SellerId = command.SellerId;

        var material = await _materialRepository.CreateAsync(materialDto);
        materialDto.Id = material.Id;

        return materialDto;
    }
}
