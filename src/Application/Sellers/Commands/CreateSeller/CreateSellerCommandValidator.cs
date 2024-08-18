namespace Application.Sellers.Commands.CreateSeller;

public class CreateSellerCommandValidator
    : AbstractValidator<CreateSellerCommand>
{
    public CreateSellerCommandValidator()
    {
        RuleFor(c => c.Dto.Name)
            .NotEmpty();
    }
}
