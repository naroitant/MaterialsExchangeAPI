namespace Application.Materials.Queries.GetMaterialById;

public record GetMaterialByIdRequestDto
{
    public Guid Id { get; init; }
}
