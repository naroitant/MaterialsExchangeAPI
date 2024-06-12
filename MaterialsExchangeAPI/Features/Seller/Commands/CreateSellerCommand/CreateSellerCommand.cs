using FluentValidation;
using MaterialsExchangeAPI.Models.DTO;
using MediatR;

namespace MaterialsExchangeAPI.Features.Seller.Commands.CreateSellerCommand
{
    /// <summary>
    /// Команда создания продавца
    /// </summary>
    public class CreateSellerCommand : IRequest<SellerDto>
    {
        /// <summary>
        /// Имя продавца
        /// </summary>
        public required string Name { get; set; }

        public class CreateSellerCommandValidator : AbstractValidator<CreateSellerCommand>
        {
            public CreateSellerCommandValidator()
            {
                RuleFor(m => m.Name).NotEmpty();
            }
        }
    }
}
