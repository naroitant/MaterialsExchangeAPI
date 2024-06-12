using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Mappers;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Seller.Commands.DeleteSellerCommand
{
    public class DeleteSellerCommandHandler : IRequestHandler<DeleteSellerCommand, SellerDto>
    {
        private readonly ISellerRepository _sellerRepository;

        public DeleteSellerCommandHandler(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<SellerDto?> Handle(DeleteSellerCommand command, CancellationToken token)
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
}
