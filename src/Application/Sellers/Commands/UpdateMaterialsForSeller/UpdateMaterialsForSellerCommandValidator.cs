using Application.Sellers.Commands.UpdateSeller;

namespace Application.Sellers.Commands.UpdateMaterialsForSeller;

public class DeleteSellerCommandValidator
    : AbstractValidator<UpdateSellerCommand>
{
    public DeleteSellerCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull();

        RuleFor(c => c.Dto.Name)
            .NotEmpty();
    }
}
