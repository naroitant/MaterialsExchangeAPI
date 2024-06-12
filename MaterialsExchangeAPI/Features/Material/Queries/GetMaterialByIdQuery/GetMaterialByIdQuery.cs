using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Material.Queries.GetMaterialByIdQuery
{
    /// <summary>
    /// Запрос на получение материала по id
    /// </summary>
    public class GetMaterialByIdQuery : IRequest<MaterialDto>
    {
        /// <summary>
        /// Уникальный идентификатор материала
        /// </summary>
        public int Id { get; set; }
    }
}
