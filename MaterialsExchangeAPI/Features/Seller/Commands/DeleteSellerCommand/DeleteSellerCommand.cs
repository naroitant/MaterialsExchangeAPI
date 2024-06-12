using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Seller.Commands.DeleteSellerCommand
{
    /// <summary>
    /// Команда удаления продавца
    /// </summary>
    public class DeleteSellerCommand : IRequest<SellerDto>
    {
        /// <summary>
        /// Уникальный идентификатор продавца
        /// </summary>
        public required int Id { get; set; }
    }
}
