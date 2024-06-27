﻿using MaterialsExchangeAPI.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaterialsExchangeAPI.Domain.Entities;

[Table("sellers")]
public class Seller : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    private readonly List<Material> _materials = new();

    public Seller(string name)
    {
        Name = name;
    }

    public static Seller Create(string name)
    {
        var seller = new Seller(name);
        return seller;
    }

    public void Update(string name)
    {
        Name = name;
    }
}
