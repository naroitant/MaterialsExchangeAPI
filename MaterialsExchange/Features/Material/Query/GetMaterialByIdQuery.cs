using MaterialsExchange.Interfaces;
using MaterialsExchange.Mappers;
using MaterialsExchange.Models.DTO;
using MediatR;

namespace MaterialsExchange.Features.Material.Query
{
    public class GetMaterialByIdQuery : IRequest<MaterialDto>
    {
        public int Id { get; set; }

		public class GetMaterialByIdCommandHandler : IRequestHandler<GetMaterialByIdQuery, MaterialDto>
        {
            private readonly IMaterialRepository _materialRepository;

            public GetMaterialByIdCommandHandler(IMaterialRepository sellerRepository)
            {
				_materialRepository = sellerRepository;
            }

            public async Task<MaterialDto> Handle(GetMaterialByIdQuery command, CancellationToken token)
            {
                int id = command.Id;
                var material = await _materialRepository.GetByIdAsync(id);
                var materialDto = material.ToMaterialDto();
                return materialDto;
            }
        }
    }
}
