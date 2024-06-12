using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Mappers;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Material.Queries.GetMaterialByIdQuery
{
    public class GetMaterialByIdQueryHandler : IRequestHandler<GetMaterialByIdQuery, MaterialDto>
    {
        private readonly IMaterialRepository _materialRepository;

        public GetMaterialByIdQueryHandler(IMaterialRepository sellerRepository)
        {
            _materialRepository = sellerRepository;
        }

        public async Task<MaterialDto?> Handle(GetMaterialByIdQuery request, CancellationToken token)
        {
            int id = request.Id;
            var material = await _materialRepository.GetByIdAsync(id);

            if (material == null)
            {
                return null;
            }

            var materialDto = material.ToMaterialDto();
            return materialDto;
        }
    }
}
