﻿using MaterialsExchange.Models.Domain;
using MaterialsExchange.Models.DTO;

namespace MaterialsExchange.Interfaces
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