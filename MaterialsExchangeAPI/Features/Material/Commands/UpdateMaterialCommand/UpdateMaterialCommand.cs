using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Material.Commands.UpdateMaterialCommand
{
    /// <summary>
    /// Команда обновления информации о материале
    /// </summary>
    public class UpdateMaterialCommand : IRequest<MaterialDto>
    {
        /// <summary>
        /// Уникальный идентификатор материала
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// Название материала
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Стоимость материала
        /// </summary>
        public required decimal Price { get; set; }

        /// <summary>
        /// Уникальный идентификатор продавца
        /// </summary>
        public required int SellerId { get; set; }
    }
}
