using MaterialsExchange.Data;
using MaterialsExchange.Interfaces;
using MaterialsExchange.Mappers;
using MaterialsExchange.Models.Domain;
using MaterialsExchange.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace MaterialsExchange.Repositories
{
    public class SellerRepository : ISellerRepository
	{
        private readonly AppDbContext _context;
        public SellerRepository(AppDbContext context)
        {
            _context = context;
        }

		public async Task<List<Seller>> GetAllAsync()
		{
			var sellers = await _context.Sellers.ToListAsync();
			return sellers;
		}

		public async Task<Seller?> GetByIdAsync(int id)
		{
            var seller = await _context.Sellers.FirstOrDefaultAsync(m => m.Id == id);
			return seller;
		}

		public async Task<Seller> CreateAsync(Seller seller)
        {
            await _context.Sellers.AddAsync(seller);
            await _context.SaveChangesAsync();
            return seller;
        }

		public async Task<Seller?> UpdateAsync(SellerDto sellerDto)
		{
            var seller = await _context.Sellers.FirstOrDefaultAsync(m => m.Id == sellerDto.Id);

			if (seller == null)
			{
				return null;
			}

			seller = sellerDto.ToSeller();

			await _context.Sellers.AddAsync(seller);
			await _context.SaveChangesAsync();
			return seller;
		}

		public async Task<Seller?> DeleteAsync(int id)
        {
            var seller = await _context.Sellers.FirstOrDefaultAsync(x => x.Id == id);

            if (seller == null)
            {
                return null;
            }

            _context.Sellers.Remove(seller);
            await _context.SaveChangesAsync();
            return seller;
        }        
    }
}
