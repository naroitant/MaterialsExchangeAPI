namespace Application.Sellers.Commands.UpdateSeller;

public class UpdateSellerCommandValidator
    : AbstractValidator<UpdateSellerCommand>
{
    public UpdateSellerCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull();

        RuleFor(c => c.Dto.Name)
            .NotEmpty();
    }
}
