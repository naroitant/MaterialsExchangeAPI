﻿namespace Application.Materials.Commands.UpdateMaterial;

public record UpdateMaterialRequestDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public Guid SellerId { get; init; }
}
