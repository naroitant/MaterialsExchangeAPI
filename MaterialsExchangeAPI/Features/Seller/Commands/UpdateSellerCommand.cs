using MaterialsExchange.Interfaces;
using MaterialsExchange.Models.DTO;
using MediatR;

namespace MaterialsExchange.Features.Seller.Commands
{
	public class UpdateSellerCommand : IRequest<SellerDto>
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public class UpdateSellerCommandHandler : IRequestHandler<UpdateSellerCommand, SellerDto>
		{
			private readonly ISellerRepository _sellerRepository;

			public UpdateSellerCommandHandler(ISellerRepository sellerRepository)
			{
				_sellerRepository = sellerRepository;
			}

			public async Task<SellerDto> Handle(UpdateSellerCommand command, CancellationToken token)
			{
				SellerDto sellerDto = new SellerDto();
				sellerDto.Id = command.Id;
				sellerDto.Name = command.Name;

				var validator = new SellerDtoValidator();
				var results = validator.Validate(sellerDto);
				await _sellerRepository.UpdateAsync(sellerDto);
				
				return sellerDto;
			}
		}
	}
}
