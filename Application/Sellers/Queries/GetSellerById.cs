using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Mappers;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Seller.Queries;

/// <summary>
/// Запрос на получение продавца по id
/// </summary>
public class GetSellerById : IRequest<SellerDto>
{
    /// <summary>
    /// Уникальный идентификатор продавца
    /// </summary>
    public int Id { get; set; }
}

public class GetSellerByIdQueryHandler : IRequestHandler<GetSellerById, SellerDto>
{
    private readonly ISellerRepository _sellerRepository;

    public GetSellerByIdQueryHandler(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public async Task<SellerDto?> Handle(GetSellerById request, CancellationToken token)
    {
        int id = request.Id;
        var seller = await _sellerRepository.GetByIdAsync(id);

        if (seller == null)
        {
            return null;
        }

        var sellerDto = seller.ToSellerDto();
        return sellerDto;
    }
}
