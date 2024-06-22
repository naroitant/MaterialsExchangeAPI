﻿using MaterialsExchangeAPI.Application.Sellers.Queries;
using MaterialsExchangeAPI.Application.Sellers.Commands.CreateSeller;
using MaterialsExchangeAPI.Application.Sellers.Commands.UpdateSeller;
using MaterialsExchangeAPI.Application.Sellers.Commands.DeleteSeller;
using MaterialsExchangeAPI.Domain.Entities;

namespace MaterialsExchangeAPI.Application.Common.Mappings;

public static class SellerMappers
{
    public static Seller ToSeller(this CreateSellerRequestDto createSellerRequestDto)
    {
        return new Seller
        {
            Name = createSellerRequestDto.Name,
        };
    }

    public static Seller ToSeller(this UpdateSellerRequestDto updateSellerRequestDto)
    {
        return new Seller
        {
            Name = updateSellerRequestDto.Name,
        };
    }

    public static CreateSellerResponseDto ToCreateSellerResponseDto(this Seller seller)
    {
        return new CreateSellerResponseDto
        {
            Id = seller.Id,
            Name = seller.Name,
        };
    }

    public static UpdateSellerResponseDto ToUpdateSellerResponseDto(this Seller seller)
    {
        return new UpdateSellerResponseDto
        {
            Id = seller.Id,
            Name = seller.Name,
        };
    }

    public static DeleteSellerResponseDto ToDeleteSellerResponseDto(this Seller seller)
    {
        return new DeleteSellerResponseDto
        {
            Id = seller.Id,
            Name = seller.Name,
        };
    }

    public static GetSellerResponseDto ToGetSellerResponseDto(this Seller seller)
    {
        return new GetSellerResponseDto
        {
            Id = seller.Id,
            Name = seller.Name,
        };
    }
}