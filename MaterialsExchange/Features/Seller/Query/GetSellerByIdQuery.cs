using MaterialsExchange.Interfaces;
using MaterialsExchange.Mappers;
using MaterialsExchange.Models.DTO;
using MediatR;

namespace MaterialsExchange.Features.Seller.Query
{
    public class GetSellerByIdQuery : IRequest<SellerDto>
    {
        public int Id { get; set; }

        public class GetSellerByIdCommandHandler : IRequestHandler<GetSellerByIdQuery, SellerDto>
        {
            private readonly ISellerRepository _sellerRepository;

            public GetSellerByIdCommandHandler(ISellerRepository sellerRepository)
            {
                _sellerRepository = sellerRepository;
            }

            public async Task<SellerDto> Handle(GetSellerByIdQuery command, CancellationToken token)
            {
                int id = command.Id;
                var seller = await _sellerRepository.GetByIdAsync(id);
                var sellerDto = seller.ToSellerDto();
                return sellerDto;
            }
        }
    }
}
