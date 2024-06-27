namespace MaterialsExchangeAPI.Application.Sellers.Commands.UpdateSeller;

public record UpdateSellerRequestDto
{
    public int Id;
    public string Name = string.Empty;
}
