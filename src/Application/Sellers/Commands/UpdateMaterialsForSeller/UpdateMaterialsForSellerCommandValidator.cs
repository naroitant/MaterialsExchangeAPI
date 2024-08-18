using Application.Sellers.Commands.UpdateSeller;

namespace Application.Sellers.Commands.UpdateMaterialsForSeller;

public class DeleteSellerCommandValidator : AbstractValidator<UpdateSellerCommand>
{
    public DeleteSellerCommandValidator()
    {
        RuleFor(m => m.Id)
            .NotNull();

        RuleFor(m => m.Dto.Name)
            .NotEmpty();
    }
}
