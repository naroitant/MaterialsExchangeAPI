using MaterialsExchange.Interfaces;
using MaterialsExchange.Mappers;
using MaterialsExchange.Models.DTO;
using MediatR;

namespace MaterialsExchange.Features.Seller.Commands
{
	public class DeleteSellerCommand : IRequest<SellerDto>
	{
		public int Id { get; set; }

		public class DeleteSellerCommandHandler : IRequestHandler<DeleteSellerCommand, SellerDto>
		{
			private readonly ISellerRepository _sellerRepository;

			public DeleteSellerCommandHandler(ISellerRepository sellerRepository)
			{
				_sellerRepository = sellerRepository;
			}

			public async Task<SellerDto> Handle(DeleteSellerCommand command, CancellationToken token)
			{
				int id = command.Id;
				var seller = await _sellerRepository.DeleteAsync(id);
				SellerDto sellerDto = seller.ToSellerDto();
				return sellerDto;
			}
		}
	}
}
