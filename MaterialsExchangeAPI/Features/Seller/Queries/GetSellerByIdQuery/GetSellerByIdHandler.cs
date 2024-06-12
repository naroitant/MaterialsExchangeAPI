using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Mappers;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Seller.Queries.GetSellerByIdQuery
{
    public class GetSellerByIdQueryHandler : IRequestHandler<GetSellerByIdQuery, SellerDto>
    {
        private readonly ISellerRepository _sellerRepository;

        public GetSellerByIdQueryHandler(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<SellerDto?> Handle(GetSellerByIdQuery request, CancellationToken token)
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
}
