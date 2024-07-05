using AutoMapper;
using MaterialsExchangeAPI.Application.Common;
using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Domain.Entities;

namespace MaterialsExchangeAPI.Application.Materials.Commands.CreateMaterial;

/// <summary>
/// Команда создания материала
/// </summary>
public record CreateMaterialCommand : IRequest<CreateMaterialResponseDto?>
{
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

public class CreateMaterialCommandHandler : BaseHandler,
    IRequestHandler<CreateMaterialCommand, CreateMaterialResponseDto?>
{
    public CreateMaterialCommandHandler(IAppDbContext context, IMapper mapper)
        : base(context, mapper) { }
        
    public async Task<CreateMaterialResponseDto?> Handle(
        CreateMaterialCommand command, CancellationToken token)
    {
        var createMaterialRequestDto =
            _mapper.Map<CreateMaterialRequestDto>(command);
        var material = _mapper.Map<Material>(createMaterialRequestDto);

        _context.Materials.Add(material);
        await _context.SaveChangesAsync(token);

        var createMaterialResponseDto =
            _mapper.Map<CreateMaterialResponseDto?>(material);
        return createMaterialResponseDto;
    }
}
