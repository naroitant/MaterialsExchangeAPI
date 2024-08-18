using Application.Common;
using Application.Common.Interfaces;
using Application.Materials.Queries;
using AutoMapper;

namespace Application.Sellers.Commands.UpdateMaterialsForSeller;

public class UpdateMaterialsForSellerCommandHandler(
    IAppDbContext context,
    IMapper mapper)
    : BaseHandler(context, mapper),
        IRequestHandler<UpdateMaterialsForSellerCommand,
            UpdateMaterialsForSellerResponseDto?>
{
    public async Task<UpdateMaterialsForSellerResponseDto?> Handle(
        UpdateMaterialsForSellerCommand command, CancellationToken token)
    {
        var materialIds = command.Dto.MaterialsId;

        var materials = await Context.Materials
            .Where(m => materialIds.Contains(m.Id))
            .Select(m => m)
            .ToListAsync(token);

        var seller = await Context.Sellers
            .Where(s => s.Id == command.Id)
            .SingleAsync(token);

        seller.UpdateMaterials(materials);

        await Context.SaveChangesAsync(token);

        var updateMaterialsForSellerResponseDto =
            new UpdateMaterialsForSellerResponseDto
            {
                Id = seller.Id,
                Dtos = await Context.Materials
                    .Where(m => materialIds.Contains(m.Id))
                    .Select(m => new GetMaterialResponseDto
                    {
                        Id = m.Id,
                        Name = m.Name,
                        Price = m.Price,
                        SellerId = m.SellerId
                    })
                    .ToListAsync(token)
            };

        return updateMaterialsForSellerResponseDto;
    }
}
