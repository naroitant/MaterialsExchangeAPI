namespace Application.Sellers.Commands.UpdateSeller;

public class UpdateSellerCommandValidator
    : AbstractValidator<UpdateSellerCommand>
{
    public UpdateSellerCommandValidator()
    {
        RuleFor(m => m.Id)
            .NotNull();

        RuleFor(m => m.Dto.Name)
            .NotEmpty();
    }
}
