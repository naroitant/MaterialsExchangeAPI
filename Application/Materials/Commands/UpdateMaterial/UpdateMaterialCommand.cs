using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;

namespace MaterialsExchangeAPI.Application.Materials.Commands.UpdateMaterial;

/// <summary>
/// Команда обновления информации о материале
/// </summary>
public class UpdateMaterialCommand : IRequest<UpdateMaterialResponseDto?>
{
    /// <summary>
    /// Уникальный идентификатор материала
    /// </summary>
    public required int Id { get; set; }

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

public class UpdateMaterialCommandHandler
    : IRequestHandler<UpdateMaterialCommand, UpdateMaterialResponseDto?>
{
    private readonly IAppDbContext _context;

    public UpdateMaterialCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<UpdateMaterialResponseDto?> Handle(
        UpdateMaterialCommand command, CancellationToken token)
    {
        var updateMaterialRequestDto = new UpdateMaterialRequestDto()
        {
            Id = command.Id,
            Name = command.Name,
            Price = command.Price,
            SellerId = command.SellerId
        };

        var updatedMaterial = await _context.Materials.FindAsync(
            new object?[] { updateMaterialRequestDto.Id }, cancellationToken: token);

        if (updatedMaterial is null)
        {
            return null;
        }

        updatedMaterial.Name = updateMaterialRequestDto.Name;
        updatedMaterial.Price = updateMaterialRequestDto.Price;
        updatedMaterial.SellerId = updateMaterialRequestDto.SellerId;

        await _context.SaveChangesAsync(token);

        var updateMaterialResponseDto =
            updatedMaterial.ToUpdateMaterialResponseDto();

        return updateMaterialResponseDto;
    }
}
