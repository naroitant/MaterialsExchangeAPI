using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Seller.Commands.UpdateSellerCommand
{
    public class UpdateSellerCommandHandler : IRequestHandler<UpdateSellerCommand, SellerDto>
    {
        private readonly ISellerRepository _sellerRepository;

        public UpdateSellerCommandHandler(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<SellerDto?> Handle(UpdateSellerCommand command, CancellationToken token)
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
}
