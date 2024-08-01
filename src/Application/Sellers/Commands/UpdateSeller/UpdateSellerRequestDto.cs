﻿namespace Application.Sellers.Commands.UpdateSeller;

public record UpdateSellerRequestDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
}
