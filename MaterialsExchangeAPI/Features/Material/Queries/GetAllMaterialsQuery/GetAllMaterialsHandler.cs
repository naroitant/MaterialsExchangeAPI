using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Mappers;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Material.Queries.GetAllMaterialsQuery
{
    public class GetAllMaterialsQueryHandler : IRequestHandler<GetAllMaterialsQuery, List<MaterialDto>>
    {
        private readonly IMaterialRepository _materialRepository;

        public GetAllMaterialsQueryHandler(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<List<MaterialDto>> Handle(GetAllMaterialsQuery request, CancellationToken token)
        {
            var materials = await _materialRepository.GetAllAsync();
            var materialDtos = materials.Select(s => s.ToMaterialDto()).ToList();
            return materialDtos;
        }
    }
}
