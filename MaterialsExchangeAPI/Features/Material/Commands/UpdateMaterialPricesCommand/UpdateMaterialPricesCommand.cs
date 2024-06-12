using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Material.Commands.UpdateMaterialPricesCommand
{
    /// <summary>
    /// Команда обновления цен материалов
    /// </summary>
    public class UpdateMaterialPricesCommand : IRequest<List<MaterialDto>> { }
}
