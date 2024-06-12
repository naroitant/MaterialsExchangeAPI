using MaterialsExchangeAPI.Models.Domain;
using MaterialsExchangeAPI.Models.DTO;

namespace MaterialsExchangeAPI.Interfaces
{
    public interface ISellerRepository
    {
        Task<List<Seller>> GetAllAsync();
        Task<Seller?> GetByIdAsync(int id);
        Task<Seller> CreateAsync(SellerDto sellerDto);
        Task<Seller?> UpdateAsync(SellerDto sellerDto);
        Task<Seller?> DeleteAsync(int id);
    }
}
