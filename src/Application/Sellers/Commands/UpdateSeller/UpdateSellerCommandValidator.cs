namespace MaterialsExchangeAPI.Application.Sellers.Commands.UpdateSeller;

public class DeleteSellerCommandValidator : AbstractValidator<UpdateSellerCommand>
{
    public DeleteSellerCommandValidator()
    {
        RuleFor(m => m.Id).NotNull();
        RuleFor(m => m.Name).NotEmpty();
    }
}
