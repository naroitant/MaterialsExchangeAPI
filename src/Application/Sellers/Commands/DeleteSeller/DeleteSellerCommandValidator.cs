namespace Application.Sellers.Commands.DeleteSeller;

public class DeleteSellerCommandValidator
    : AbstractValidator<DeleteSellerCommand>
{
    public DeleteSellerCommandValidator()
    {
        RuleFor(c => c.id)
            .NotNull();
    }
}
