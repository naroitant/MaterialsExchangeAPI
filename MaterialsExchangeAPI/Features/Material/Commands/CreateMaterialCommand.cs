using MaterialsExchange.Interfaces;
using MaterialsExchange.Models.DTO;
using MediatR;

namespace MaterialsExchange.Features.Material.Commands
{
    public class CreateMaterialCommand : IRequest<MaterialDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public decimal Price { get; set; }
		public int SellerId { get; set; }

		public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, MaterialDto>
        {
            private readonly IMaterialRepository _materialRepository;

            public CreateMaterialCommandHandler(IMaterialRepository materialRepository)
			{
                _materialRepository = materialRepository;
            }

            public async Task<MaterialDto> Handle(CreateMaterialCommand command, CancellationToken token)
            {
				MaterialDto materialDto = new MaterialDto();
				materialDto.Id = command.Id;
				materialDto.Name = command.Name;
				materialDto.Price = command.Price;
				materialDto.SellerId = command.SellerId;

				var validator = new MaterialDtoValidator();
				var results = validator.Validate(materialDto);
				await _materialRepository.CreateAsync(materialDto);

				return materialDto;
            }
        }
    }
}
