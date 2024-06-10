using MaterialsExchange.Data;
using MaterialsExchange.Interfaces;
using MaterialsExchange.Mappers;
using MaterialsExchange.Models.Domain;
using MaterialsExchange.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace MaterialsExchange.Repositories
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
            var material = await _context.Materials.FirstOrDefaultAsync(m => m.Id == id);
			return material;
		}

		public async Task<Material> CreateAsync(MaterialDto materialDto)
        {
            var material = materialDto.ToMaterial();
            await _context.Materials.AddAsync(material);
            await _context.SaveChangesAsync();
            return material;
        }

		public async Task<Material?> UpdateAsync(MaterialDto materialDto)
		{
            var material = materialDto.ToMaterial();

			if (material == null)
			{
				return null;
			}

			await _context.SaveChangesAsync();
			return material;
		}

		public async Task<Material?> DeleteAsync(int id)
        {
            var material = await _context.Materials.FirstOrDefaultAsync(x => x.Id == id);

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
