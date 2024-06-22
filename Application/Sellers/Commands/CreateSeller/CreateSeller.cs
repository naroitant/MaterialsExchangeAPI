using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Seller.Commands.CreateSellerCommand;

/// <summary>
/// Команда создания продавца
/// </summary>
public class CreateSeller : IRequest<SellerDto>
{
    /// <summary>
    /// Имя продавца
    /// </summary>
    public required string Name { get; set; }
}

public class CreateSellerCommandHandler : IRequestHandler<CreateSeller, SellerDto>
{
    private readonly ISellerRepository _sellerRepository;

    public CreateSellerCommandHandler(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public async Task<SellerDto> Handle(CreateSeller command, CancellationToken token)
    {
        SellerDto sellerDto = new SellerDto();
        sellerDto.Name = command.Name;

        var seller = await _sellerRepository.CreateAsync(sellerDto);

        sellerDto.Id = seller.Id;
        return sellerDto;
    }
}
