using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Mappers;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Seller.Commands.DeleteSellerCommand;

/// <summary>
/// Команда удаления продавца
/// </summary>
public class DeleteSeller : IRequest<SellerDto>
{
    /// <summary>
    /// Уникальный идентификатор продавца
    /// </summary>
    public required int Id { get; set; }
}

public class DeleteSellerCommandHandler : IRequestHandler<DeleteSeller, SellerDto>
{
    private readonly ISellerRepository _sellerRepository;

    public DeleteSellerCommandHandler(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public async Task<SellerDto?> Handle(DeleteSeller command, CancellationToken token)
    {
        int id = command.Id;
        var seller = await _sellerRepository.DeleteAsync(id);

        if (seller == null)
        {
            return null;
        }

        SellerDto sellerDto = seller.ToSellerDto();
        return sellerDto;
    }
}
