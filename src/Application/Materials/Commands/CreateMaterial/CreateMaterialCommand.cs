using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Application.Common.Mappings;
using MaterialsExchangeAPI.Domain.Entities;
using System.Data;

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

public class CreateMaterialHandler
    : IRequestHandler<CreateMaterialCommand, CreateMaterialResponseDto?>
{
    private readonly IAppDbContext _context;

    public CreateMaterialHandler(IAppDbContext context)
    {
        _context = context;
    }
        
    public async Task<CreateMaterialResponseDto?> Handle(
        CreateMaterialCommand command, CancellationToken token)
    {
        var createMaterialRequestDto = new CreateMaterialRequestDto()
        {
            Name = command.Name,
            Price = command.Price,
            SellerId = command.SellerId,
        };

        var material = Material.Create(
            createMaterialRequestDto.Name,
            createMaterialRequestDto.Price,
            createMaterialRequestDto.SellerId
        );

        // Обращаемся к последнему материалу из БД, чтобы на основе его id
        // установить id нового материала.
        var latestMaterial = await _context.Materials
            .OrderBy(l => l.Id)
            .LastOrDefaultAsync(token);

        if (latestMaterial is null)
        {
            material.SetId(1);
        }
        else
        {
            material.SetId(latestMaterial.Id + 1);
        }

        _context.Materials.Add(material);
        await _context.SaveChangesAsync(token);

        var createMaterialResponseDto = material.ToCreateMaterialResponseDto();

        return createMaterialResponseDto;
    }
}
