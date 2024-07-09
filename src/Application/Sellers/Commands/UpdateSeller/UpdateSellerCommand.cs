using AutoMapper;
using Application.Common;
using Application.Common.Interfaces;

namespace Application.Sellers.Commands.UpdateSeller;

/// <summary>
/// Команда обновления продавца
/// </summary>
public record UpdateSellerCommand : IRequest<UpdateSellerResponseDto?>
{
    /// <summary>
    /// Уникальный идентификатор продавца
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Имя продавца
    /// </summary>
    public string Name { get; init; } = string.Empty;
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
            Mapper.Map<UpdateSellerRequestDto>(command);
        var seller = await Context.Sellers.FirstOrDefaultAsync(
            u => u.Id == updateSellerRequestDto.Id, token);

        if (seller is null)
        {
            return null;
        }

        seller.Update(updateSellerRequestDto.Name);
        await Context.SaveChangesAsync(token);

        var updateSellerResponseDto =
            Mapper.Map<UpdateSellerResponseDto>(seller);
        return updateSellerResponseDto;
    }
}
