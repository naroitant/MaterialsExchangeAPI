using FluentValidation;

namespace MaterialsExchangeAPI.Features.Seller.Commands.CreateSellerCommand
{
    public class CreateSellerCommandValidator : AbstractValidator<CreateSellerCommand>
    {
        public CreateSellerCommandValidator()
        {
            RuleFor(m => m.Name).NotEmpty();
        }
    }
}
