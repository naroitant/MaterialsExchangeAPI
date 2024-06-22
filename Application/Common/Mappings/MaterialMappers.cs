using MaterialsExchangeAPI.Application.Materials.Commands.CreateMaterial;
using MaterialsExchangeAPI.Application.Materials.Commands.DeleteMaterial;
using MaterialsExchangeAPI.Application.Materials.Commands.UpdateMaterial;
using MaterialsExchangeAPI.Application.Materials.Commands.UpdateMaterialPrices;
using MaterialsExchangeAPI.Application.Materials.Queries;
using MaterialsExchangeAPI.Domain.Entities;

namespace MaterialsExchangeAPI.Application.Common.Mappings;

public static class MaterialMappers
{
    public static Material ToMaterial(this CreateMaterialRequestDto createMaterialRequestDto)
    {
        return new Material
        {
            Name = createMaterialRequestDto.Name,
            Price = createMaterialRequestDto.Price,
            SellerId = createMaterialRequestDto.SellerId,
        };
    }

    public static Material ToMaterial(this UpdateMaterialRequestDto updateMaterialRequestDto)
    {
        return new Material
        {
            Name = updateMaterialRequestDto.Name,
            Price = updateMaterialRequestDto.Price,
            SellerId = updateMaterialRequestDto.SellerId,
        };
    }

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

    public static DeleteMaterialResponseDto ToDeleteMaterialResponseDto(this Material material)
    {
        return new DeleteMaterialResponseDto
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

    public static UpdateMaterialPriceResponseDto ToUpdateMaterialPriceResponseDto(this Material material)
    {
        return new UpdateMaterialPriceResponseDto
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
