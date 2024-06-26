﻿using MaterialsExchangeAPI.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaterialsExchangeAPI.Domain.Entities;

[Table("materials")]
public class Material : BaseEntity
{
    public string Name { get; private set; }

    public decimal Price { get; private set; }

    public Seller? Seller { get; private set; }

    public int SellerId { get; private set; }

    public Material(string name, decimal price, int sellerId)
    {
        Name = name;
        Price = price;
        SellerId = sellerId;
    }

    public static Material Create(string name, decimal price, int sellerId)
    {
        var material = new Material(name, price, sellerId);
        return material;
    }

    public void Update(string name, decimal price, int sellerId)
    {
        Name = name;
        Price = price;
        SellerId = sellerId;
    }

    public void UpdatePriceRandomly()
    {
        int minValue = 1;
        int maxValue = 100;
        Random rand = new();

        Price = rand.Next(minValue, maxValue);
    }
}
