using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Mappers;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Seller.Queries;

/// <summary>
/// Запрос на получение всех продавцов
/// </summary>
public class GetAllSellers : IRequest<List<SellerDto>> { }

public class GetAllSellersQueryHandler : IRequestHandler<GetAllSellers, List<SellerDto>>
{
    private readonly ISellerRepository _sellerRepository;

    public GetAllSellersQueryHandler(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public async Task<List<SellerDto>> Handle(GetAllSellers request, CancellationToken token)
    {
        var sellers = await _sellerRepository.GetAllAsync();
        var sellerDtos = sellers.Select(s => s.ToSellerDto()).ToList();
        return sellerDtos;
    }
}
