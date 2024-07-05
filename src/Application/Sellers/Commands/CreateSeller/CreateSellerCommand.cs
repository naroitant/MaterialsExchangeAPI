using AutoMapper;
using MaterialsExchangeAPI.Application.Common;
using MaterialsExchangeAPI.Application.Common.Interfaces;
using MaterialsExchangeAPI.Domain.Entities;

namespace MaterialsExchangeAPI.Application.Sellers.Commands.CreateSeller;

/// <summary>
/// Команда создания продавца
/// </summary>
public record CreateSellerCommand : IRequest<CreateSellerResponseDto?>
{
    /// <summary>
    /// Имя продавца
    /// </summary>
    public string Name = string.Empty;
}

public class CreateSellerCommandHandler : BaseHandler,
    IRequestHandler<CreateSellerCommand, CreateSellerResponseDto?>
{
    public CreateSellerCommandHandler(IAppDbContext context, IMapper mapper)
        : base(context, mapper) { }

    public async Task<CreateSellerResponseDto?> Handle(
        CreateSellerCommand command, CancellationToken token)
    {
        var createSellerRequestDto =
            _mapper.Map<CreateSellerRequestDto>(command);
        var seller = _mapper.Map<Seller>(createSellerRequestDto);

        _context.Sellers.Add(seller);
        await _context.SaveChangesAsync(token);

        var createSellerResponseDto =
            _mapper.Map<CreateSellerResponseDto?>(seller);
        return createSellerResponseDto;
    }
}
