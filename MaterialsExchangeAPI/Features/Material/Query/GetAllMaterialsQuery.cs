using MaterialsExchange.Interfaces;
using MaterialsExchange.Mappers;
using MaterialsExchange.Models.DTO;
using MediatR;

namespace MaterialsExchange.Features.Material.Query
{
    public class GetAllMaterialsQuery : IRequest<List<MaterialDto>>
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
}
