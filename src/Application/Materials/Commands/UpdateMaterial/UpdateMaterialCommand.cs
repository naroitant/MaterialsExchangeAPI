using AutoMapper;
using MaterialsExchangeAPI.Application.Common;
using MaterialsExchangeAPI.Application.Common.Interfaces;

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

public class UpdateMaterialCommandHandler : BaseHandler,
    IRequestHandler<UpdateMaterialCommand, UpdateMaterialResponseDto?>
{
    public UpdateMaterialCommandHandler(IAppDbContext context, IMapper mapper)
        : base(context, mapper) { }

    public async Task<UpdateMaterialResponseDto?> Handle(
        UpdateMaterialCommand command, CancellationToken token)
    {
        var updateMaterialRequestDto =
            _mapper.Map<UpdateMaterialRequestDto>(command);
        var material = await _context.Materials.FirstOrDefaultAsync(
            u => u.Id == updateMaterialRequestDto.Id, token);

        if (material is null)
        {
            return null;
        }

        material.Update(
            updateMaterialRequestDto.Name, 
            updateMaterialRequestDto.Price, 
            updateMaterialRequestDto.SellerId
        );
        await _context.SaveChangesAsync(token);

        var updateMaterialResponseDto =
            _mapper.Map<UpdateMaterialResponseDto>(material);
        return updateMaterialResponseDto;
    }
}
