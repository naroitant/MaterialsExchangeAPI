﻿using MaterialsExchange.Models.Domain;
using MaterialsExchange.Models.DTO;

namespace MaterialsExchange.Interfaces
{
	public interface ISellerRepository
	{
		Task<List<Seller>> GetAllAsync();
		Task<Seller?> GetByIdAsync(int id);
		Task<Seller> CreateAsync(Seller seller);
		Task<Seller?> UpdateAsync(SellerDto sellerDto);
		Task<Seller?> DeleteAsync(int id);
	}
}
