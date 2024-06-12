using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Seller.Commands.UpdateSellerCommand
{
    /// <summary>
    /// Команда обновления продавца
    /// </summary>
    public class UpdateSellerCommand : IRequest<SellerDto>
    {
        /// <summary>
        /// Уникальный идентификатор продавца
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// Имя продавца
        /// </summary>
        public required string Name { get; set; }
    }
}
