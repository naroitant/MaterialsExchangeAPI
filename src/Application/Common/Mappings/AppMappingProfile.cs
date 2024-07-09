using AutoMapper;
using Application.Materials.Commands.CreateMaterial;
using Application.Materials.Commands.UpdateMaterial;
using Application.Materials.Commands.DeleteMaterial;
using Application.Materials.Queries;
using Application.Materials.Queries.GetMaterialById;
using Application.Sellers.Commands.CreateSeller;
using Application.Sellers.Commands.UpdateSeller;
using Application.Sellers.Commands.DeleteSeller;
using Application.Sellers.Queries;
using Application.Sellers.Queries.GetSellerById;
using Domain.Entities;

namespace Application.Common.Mappings;

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
