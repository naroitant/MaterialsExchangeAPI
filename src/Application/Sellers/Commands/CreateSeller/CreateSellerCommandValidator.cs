namespace Application.Sellers.Commands.CreateSeller;

public class CreateSellerCommandValidator
    : AbstractValidator<CreateSellerCommand>
{
    public CreateSellerCommandValidator()
    {
        RuleFor(m => m.Dto.Name)
            .NotEmpty();
    }
}
