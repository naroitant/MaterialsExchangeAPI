using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Seller.Queries.GetSellerByIdQuery
{
    /// <summary>
    /// Запрос на получение продавца по id
    /// </summary>
    public class GetSellerByIdQuery : IRequest<SellerDto>
    {
        /// <summary>
        /// Уникальный идентификатор продавца
        /// </summary>
        public int Id { get; set; }
    }
}
