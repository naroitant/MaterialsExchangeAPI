using MaterialsExchange.Interfaces;
using MaterialsExchange.Models.DTO;
using MediatR;

namespace MaterialsExchange.Features.Seller.Commands
{
    public class CreateSellerCommand : IRequest<SellerDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

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
                sellerDto.Id = command.Id;
                sellerDto.Name = command.Name;

				var validator = new SellerDtoValidator();
				var results = validator.Validate(sellerDto);
				await _sellerRepository.CreateAsync(sellerDto);

				return sellerDto;
            }
        }
    }
}
