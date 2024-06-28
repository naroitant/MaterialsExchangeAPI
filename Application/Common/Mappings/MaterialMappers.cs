using MaterialsExchangeAPI.Application.Materials.Commands.CreateMaterial;
using MaterialsExchangeAPI.Application.Materials.Commands.UpdateMaterial;
using MaterialsExchangeAPI.Application.Materials.Queries;
using MaterialsExchangeAPI.Domain.Entities;

namespace MaterialsExchangeAPI.Application.Common.Mappings;

public static class MaterialMappers
{
    public static CreateMaterialResponseDto ToCreateMaterialResponseDto(this Material material)
    {
        return new CreateMaterialResponseDto
        {
            Id = material.Id,
            Name = material.Name,
            Price = material.Price,
            SellerId = material.SellerId,
        };
    }

    public static UpdateMaterialResponseDto ToUpdateMaterialResponseDto(this Material material)
    {
        return new UpdateMaterialResponseDto
        {
            Id = material.Id,
            Name = material.Name,
            Price = material.Price,
            SellerId = material.SellerId,
        };
    }

    public static GetMaterialResponseDto ToGetMaterialResponseDto(this Material material)
    {
        return new GetMaterialResponseDto
        {
            Id = material.Id,
            Name = material.Name,
            Price = material.Price,
            SellerId = material.SellerId,
        };
    }
}
