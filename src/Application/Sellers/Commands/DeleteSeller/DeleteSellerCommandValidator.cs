namespace Application.Sellers.Commands.DeleteSeller;

public class DeleteSellerCommandValidator
    : AbstractValidator<DeleteSellerCommand>
{
    public DeleteSellerCommandValidator()
    {
        RuleFor(m => m.Dto.Id)
            .NotNull();
    }
}
