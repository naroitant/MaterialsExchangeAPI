using AutoMapper;
using Application.Common;
using Application.Common.Interfaces;

namespace Application.Materials.Commands.UpdateMaterial;

/// <summary>
/// Команда обновления информации о материале
/// </summary>
public record UpdateMaterialCommand : IRequest<UpdateMaterialResponseDto?>
{
    /// <summary>
    /// Уникальный идентификатор материала
    /// </summary>
    public int Id { get; init; }


    /// <summary>
    /// Название материала
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// Стоимость материала
    /// </summary>
    public decimal Price { get; init; }

    /// <summary>
    /// Уникальный идентификатор продавца
    /// </summary>
    public int SellerId { get; init; }
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
            Mapper.Map<UpdateMaterialRequestDto>(command);
        var material = await Context.Materials.FirstOrDefaultAsync(
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
        await Context.SaveChangesAsync(token);

        var updateMaterialResponseDto =
            Mapper.Map<UpdateMaterialResponseDto>(material);
        return updateMaterialResponseDto;
    }
}
