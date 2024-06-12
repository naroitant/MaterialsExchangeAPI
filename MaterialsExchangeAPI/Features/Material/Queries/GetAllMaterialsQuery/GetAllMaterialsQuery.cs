using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Material.Queries.GetAllMaterialsQuery
{
    /// <summary>
    /// Запрос на получение всех материалов
    /// </summary>
    public class GetAllMaterialsQuery : IRequest<List<MaterialDto>> { }
}
