using AutoMapper;
using MaterialsExchangeAPI.Application.Common;
using MaterialsExchangeAPI.Application.Common.Interfaces;

namespace MaterialsExchangeAPI.Application.Sellers.Commands.UpdateSeller;

/// <summary>
/// Команда обновления продавца
/// </summary>
public record UpdateSellerCommand : IRequest<UpdateSellerResponseDto?>
{
    /// <summary>
    /// Уникальный идентификатор продавца
    /// </summary>
    public int Id;

    /// <summary>
    /// Имя продавца
    /// </summary>
    public string Name = string.Empty;
}

public class UpdateSellerCommandHandler : BaseHandler,
    IRequestHandler<UpdateSellerCommand, UpdateSellerResponseDto?>
{
    public UpdateSellerCommandHandler(IAppDbContext context, IMapper mapper)
        : base(context, mapper) { }

    public async Task<UpdateSellerResponseDto?> Handle(
        UpdateSellerCommand command, CancellationToken token)
    {
        var updateSellerRequestDto =
            _mapper.Map<UpdateSellerRequestDto>(command);
        var seller = await _context.Sellers.FirstOrDefaultAsync(
            u => u.Id == updateSellerRequestDto.Id, token);

        if (seller is null)
        {
            return null;
        }

        seller.Update(updateSellerRequestDto.Name);
        await _context.SaveChangesAsync(token);

        var updateSellerResponseDto =
            _mapper.Map<UpdateSellerResponseDto>(seller);
        return updateSellerResponseDto;
    }
}
