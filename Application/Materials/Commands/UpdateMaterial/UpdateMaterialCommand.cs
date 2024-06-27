using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;

namespace MaterialsExchangeAPI.Application.Materials.Commands.UpdateMaterial;

/// <summary>
/// Команда обновления информации о материале
/// </summary>
public record UpdateMaterialCommand : IRequest<UpdateMaterialResponseDto?>
{
    /// <summary>
    /// Уникальный идентификатор материала
    /// </summary>
    public int Id;

    /// <summary>
    /// Название материала
    /// </summary>
    public string Name = string.Empty;

    /// <summary>
    /// Стоимость материала
    /// </summary>
    public decimal Price;

    /// <summary>
    /// Уникальный идентификатор продавца
    /// </summary>
    public int SellerId;
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

        updatedMaterial.Update(
            updateMaterialRequestDto.Name, 
            updateMaterialRequestDto.Price, 
            updateMaterialRequestDto.SellerId
        );
        await _context.SaveChangesAsync(token);

        var updateMaterialResponseDto =
            updatedMaterial.ToUpdateMaterialResponseDto();

        return updateMaterialResponseDto;
    }
}
