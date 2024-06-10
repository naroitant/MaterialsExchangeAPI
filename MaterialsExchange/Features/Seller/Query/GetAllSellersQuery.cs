using MaterialsExchange.Interfaces;
using MaterialsExchange.Mappers;
using MaterialsExchange.Models.DTO;
using MediatR;

namespace MaterialsExchange.Features.Seller.Query
{
    public class GetAllSellersQuery : IRequest<List<SellerDto>>
    {
        public class GetAllSellersQueryHandler : IRequestHandler<GetAllSellersQuery, List<SellerDto>>
        {
            private readonly ISellerRepository _sellerRepository;

            public GetAllSellersQueryHandler(ISellerRepository sellerRepository)
            {
                _sellerRepository = sellerRepository;
            }

            public async Task<List<SellerDto>> Handle(GetAllSellersQuery request, CancellationToken token)
            {
                var sellers = await _sellerRepository.GetAllAsync();
                var sellerDtos = sellers.Select(s => s.ToSellerDto()).ToList();
                return sellerDtos;
            }
        }
    }
}
