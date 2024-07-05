using AutoMapper;
using MaterialsExchangeAPI.Application.Materials.Commands.CreateMaterial;
using MaterialsExchangeAPI.Application.Materials.Commands.UpdateMaterial;
using MaterialsExchangeAPI.Application.Materials.Commands.DeleteMaterial;
using MaterialsExchangeAPI.Application.Materials.Queries;
using MaterialsExchangeAPI.Application.Sellers.Commands.CreateSeller;
using MaterialsExchangeAPI.Application.Sellers.Commands.UpdateSeller;
using MaterialsExchangeAPI.Application.Sellers.Commands.DeleteSeller;
using MaterialsExchangeAPI.Application.Sellers.Queries;
using MaterialsExchangeAPI.Domain.Entities;
using MaterialsExchangeAPI.Application.Materials.Queries.GetMaterialById;
using MaterialsExchangeAPI.Application.Sellers.Queries.GetSellerById;

namespace MaterialsExchangeAPI.Application.Common.Mappings;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<CreateMaterialCommand, CreateMaterialRequestDto>();
        CreateMap<UpdateMaterialCommand, UpdateMaterialRequestDto>();
        CreateMap<DeleteMaterialCommand, DeleteMaterialRequestDto>();
        CreateMap<GetMaterialByIdQuery, GetMaterialByIdRequestDto>();
        CreateMap<CreateMaterialRequestDto, Material>();
        CreateMap<Material, CreateMaterialResponseDto?>();
        CreateMap<Material, UpdateMaterialResponseDto>();
        CreateMap<Material, GetMaterialResponseDto>();

        CreateMap<CreateSellerCommand, CreateSellerRequestDto>();
        CreateMap<UpdateSellerCommand, UpdateSellerRequestDto>();
        CreateMap<DeleteSellerCommand, DeleteSellerRequestDto>();
        CreateMap<GetSellerByIdQuery, GetSellerByIdRequestDto>();
        CreateMap<CreateSellerRequestDto, Seller>();
        CreateMap<Seller, CreateSellerResponseDto?>();
        CreateMap<Seller, UpdateSellerResponseDto>();
        CreateMap<Seller, GetSellerResponseDto>();
    }
}
