using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Seller.Queries.GetAllSellersQuery
{
    /// <summary>
    /// Запрос на получение всех продавцов
    /// </summary>
    public class GetAllSellersQuery : IRequest<List<SellerDto>> { }
}
