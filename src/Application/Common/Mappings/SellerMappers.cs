using MaterialsExchangeAPI.Application.Sellers.Commands.CreateSeller;
using MaterialsExchangeAPI.Application.Sellers.Commands.UpdateSeller;
using MaterialsExchangeAPI.Application.Sellers.Queries;
using MaterialsExchangeAPI.Domain.Entities;

namespace MaterialsExchangeAPI.Application.Common.Mappings;

public static class SellerMappers
{
    public static CreateSellerResponseDto ToCreateSellerResponseDto(
        this Seller seller)
    {
        return new CreateSellerResponseDto
        {
            Id = seller.Id,
            Name = seller.Name,
        };
    }

    public static UpdateSellerResponseDto ToUpdateSellerResponseDto(
        this Seller seller)
    {
        return new UpdateSellerResponseDto
        {
            Id = seller.Id,
            Name = seller.Name,
        };
    }

    public static GetSellerResponseDto ToGetSellerResponseDto(
        this Seller seller)
    {
        return new GetSellerResponseDto
        {
            Id = seller.Id,
            Name = seller.Name,
        };
    }
}
