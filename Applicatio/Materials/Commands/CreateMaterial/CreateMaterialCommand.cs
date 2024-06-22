using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;

namespace MaterialsExchangeAPI.Application.Materials.Commands.CreateMaterial;

/// <summary>
/// Команда создания материала
/// </summary>
public record CreateMaterialCommand : IRequest<CreateMaterialResponseDto>
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

public class CreateMaterialHandler
    : IRequestHandler<CreateMaterialCommand, CreateMaterialResponseDto>
{
    private readonly IAppDbContext _context;

    public CreateMaterialHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<CreateMaterialResponseDto> Handle(
        CreateMaterialCommand command, CancellationToken token)
    {
        var createMaterialRequestDto = new CreateMaterialRequestDto() {
            Name = command.Name,
            Price = command.Price,
            SellerId = command.SellerId
        };

        var material = createMaterialRequestDto.ToMaterial();
        var latestMaterial = 
            await _context.Materials.OrderBy(l => l.Id).LastOrDefaultAsync(token);

        if (latestMaterial == null)
        {
            material.Id = 1;
        }
        else
        {
            material.Id = latestMaterial.Id + 1;
        }

        _context.Materials.Add(material);
        await _context.SaveChangesAsync(token);

        var createMaterialResponseDto = material.ToCreateMaterialResponseDto();

        return createMaterialResponseDto;
    }
}
