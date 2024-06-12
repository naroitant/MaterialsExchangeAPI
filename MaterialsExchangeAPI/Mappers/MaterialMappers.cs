using MaterialsExchangeAPI.Models.Domain;
using MaterialsExchangeAPI.Models.DTO;

namespace MaterialsExchangeAPI.Mappers
{
    public static class MaterialMappers
    {
        public static MaterialDto ToMaterialDto(this Material material)
        {
            return new MaterialDto
            {
                Id = material.Id,
                Name = material.Name,
                Price = material.Price,
                SellerId = material.SellerId,
            };
        }

        public static Material ToMaterial(this MaterialDto materialDto)
        {
            return new Material
            {
                Id = materialDto.Id,
                Name = materialDto.Name,
                Price = materialDto.Price,
                SellerId = materialDto.SellerId,
            };
        }
    }
}
