using MaterialsExchangeAPI.Data;
using MaterialsExchangeAPI.Interfaces;
using MaterialsExchangeAPI.Mappers;
using MaterialsExchangeAPI.Models.Domain;
using MaterialsExchangeAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace MaterialsExchangeAPI.Repositories
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
            var seller = await _context.Sellers.FindAsync(id);
            return seller;
        }

        public async Task<Seller> CreateAsync(SellerDto sellerDto)
        {
            // Получаем последнего продавца из БД.
            var latestSeller = await _context.Sellers.OrderBy(l => l.Id).LastOrDefaultAsync();
            var seller = sellerDto.ToSeller();

            if (latestSeller == null)
            {
                seller.Id = 1;
            }
            else
            {
                // Используем id последнего продавца, чтобы присвоить следующий id для нового продавца.
                seller.Id = latestSeller.Id + 1;
            }

            await _context.Sellers.AddAsync(seller);
            await _context.SaveChangesAsync();

            return seller;
        }

        public async Task<Seller?> UpdateAsync(SellerDto sellerDto)
        {
            var seller = await _context.Sellers.FindAsync(sellerDto.Id);

            if (seller == null)
            {
                return null;
            }

            seller.Name = sellerDto.Name;
            await _context.SaveChangesAsync();

            return seller;
        }

        public async Task<Seller?> DeleteAsync(int id)
        {
            var seller = await _context.Sellers.FindAsync(id);

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
