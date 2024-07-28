using AutoMapper;
using Application.Common;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Materials.Commands.CreateMaterial;

/// <summary>
/// Команда создания материала
/// </summary>
public record CreateMaterialCommand : IRequest<CreateMaterialResponseDto?>
{
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

public class CreateMaterialCommandHandler : BaseHandler,
    IRequestHandler<CreateMaterialCommand, CreateMaterialResponseDto?>
{
    public CreateMaterialCommandHandler(IAppDbContext context, IMapper mapper)
        : base(context, mapper) { }
        
    public async Task<CreateMaterialResponseDto?> Handle(
        CreateMaterialCommand command, CancellationToken token)
    {
        var createMaterialRequestDto =
            Mapper.Map<CreateMaterialRequestDto>(command);
        var material = Mapper.Map<Material>(createMaterialRequestDto);
        Context.Materials.Add(material);
        await Context.SaveChangesAsync(token);

        var createMaterialResponseDto =
            Mapper.Map<CreateMaterialResponseDto?>(material);
        return createMaterialResponseDto;
    }
}
