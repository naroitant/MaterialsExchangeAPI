using MaterialsExchangeAPI.Data;
using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Mappers;
using MaterialsExchangeAPI.Models.Domain;
using MaterialsExchangeAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace MaterialsExchangeAPI.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly AppDbContext _context;
        public MaterialRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Material>> GetAllAsync()
        {
            var materials = await _context.Materials.ToListAsync();
            return materials;
        }

        public async Task<Material?> GetByIdAsync(int id)
        {
            var material = await _context.Materials.FindAsync(id);
            return material;
        }

        public async Task<Material> CreateAsync(MaterialDto materialDto)
        {
            // Получаем последний материал из БД.
            var latestMaterial = await _context.Materials.OrderBy(l => l.Id).LastOrDefaultAsync();
            var material = materialDto.ToMaterial();

            if (latestMaterial == null)
            {
                material.Id = 1;
            }
            else
            {
                // Используем id последнего материала, чтобы присвоить следующий id для нового материала.
                material.Id = latestMaterial.Id + 1;
            }

            await _context.Materials.AddAsync(material);
            await _context.SaveChangesAsync();

            return material;
        }

        public async Task<Material?> UpdateAsync(MaterialDto materialDto)
        {
            var material = await _context.Materials.FindAsync(materialDto.Id);

            if (material == null)
            {
                return null;
            }

            material.Name = materialDto.Name;
            material.Price = materialDto.Price;
            material.SellerId = materialDto.SellerId;
            await _context.SaveChangesAsync();

            return material;
        }

        public async Task<Material?> DeleteAsync(int id)
        {
            var material = await _context.Materials.FindAsync(id);

            if (material == null)
            {
                return null;
            }

            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();

            return material;
        }        
    }
}
