using FluentValidation;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Material.Commands.CreateMaterialCommand
{
    /// <summary>
    /// Команда создания материала
    /// </summary>
    public class CreateMaterialCommand : IRequest<MaterialDto>
    {
        /// <summary>
        /// Название материала
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Стоимость материала
        /// </summary>
        public required decimal Price { get; set; }

        /// <summary>
        /// Уникальный идентификатор продавца
        /// </summary>
        public required int SellerId { get; set; }

        public class CreateMaterialCommandValidator : AbstractValidator<CreateMaterialCommand>
        {
            public CreateMaterialCommandValidator()
            {
                RuleFor(m => m.Name).NotEmpty();
                RuleFor(m => m.Price).NotNull().GreaterThan(0);
                RuleFor(m => m.SellerId).NotNull();
            }
        }
    }
}
