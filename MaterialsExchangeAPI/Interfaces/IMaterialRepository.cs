using MaterialsExchangeAPI.Models.Domain;
using MaterialsExchangeAPI.Models.DTO;

namespace MaterialsExchangeAPI.Interfaces
{
    public interface IMaterialRepository
    {
        Task<List<Material>> GetAllAsync();
        Task<Material?> GetByIdAsync(int id);
        Task<Material> CreateAsync(MaterialDto materialDto);
        Task<Material?> UpdateAsync(MaterialDto materialDto);
        Task<Material?> DeleteAsync(int id);
    }
}
