using MaterialsExchangeAPI.Models.Domain;
using MaterialsExchangeAPI.Models.DTO;

namespace MaterialsExchangeAPI.Mappers
{
    public static class SellerMappers
    {
        public static SellerDto ToSellerDto(this Seller seller)
        {
            return new SellerDto
            {
                Id = seller.Id,
                Name = seller.Name,
            };
        }

        public static Seller ToSeller(this SellerDto sellerDto)
        {
            return new Seller
            {
                Id = sellerDto.Id,
                Name = sellerDto.Name,
            };
        }
    }
}
