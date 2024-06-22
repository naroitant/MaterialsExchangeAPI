using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Seller.Commands.UpdateSellerCommand;

/// <summary>
/// Команда обновления продавца
/// </summary>
public class UpdateSeller : IRequest<SellerDto>
{
    /// <summary>
    /// Уникальный идентификатор продавца
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Имя продавца
    /// </summary>
    public required string Name { get; set; }
}

public class UpdateSellerCommandHandler : IRequestHandler<UpdateSeller, SellerDto>
{
    private readonly ISellerRepository _sellerRepository;

    public UpdateSellerCommandHandler(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public async Task<SellerDto?> Handle(UpdateSeller command, CancellationToken token)
    {
        SellerDto sellerDto = new SellerDto();
        sellerDto.Id = command.Id;
        sellerDto.Name = command.Name;

        var updatedSeller = await _sellerRepository.UpdateAsync(sellerDto); ;

        if (updatedSeller == null)
        {
            return null;
        }

        return sellerDto;
    }
}
