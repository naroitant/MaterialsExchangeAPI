using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Material.Commands.DeleteMaterialCommand
{
    /// <summary>
    /// Команда удаления материала
    /// </summary>
    public class DeleteMaterialCommand : IRequest<MaterialDto>
    {
        /// <summary>
        /// Уникальный идентификатор материала
        /// </summary>
        public required int Id { get; set; }
    }
}
