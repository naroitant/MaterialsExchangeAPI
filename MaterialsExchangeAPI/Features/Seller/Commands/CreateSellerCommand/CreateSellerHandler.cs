using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Seller.Commands.CreateSellerCommand
{
    public class CreateSellerCommandHandler : IRequestHandler<CreateSellerCommand, SellerDto>
    {
        private readonly ISellerRepository _sellerRepository;

        public CreateSellerCommandHandler(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<SellerDto> Handle(CreateSellerCommand command, CancellationToken token)
        {
            SellerDto sellerDto = new SellerDto();
            sellerDto.Name = command.Name;

            var seller = await _sellerRepository.CreateAsync(sellerDto);

            sellerDto.Id = seller.Id;
            return sellerDto;
        }
    }
}
