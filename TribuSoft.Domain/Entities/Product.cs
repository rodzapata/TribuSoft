using System;
using System.Collections.Generic;
using System.Text;

namespace TribuSoft.Domain.Entities;

public sealed class Product
{
    public long Id { get; private set; }
    //public long Id { get; init; }
    public string Name { get; private set; } = default!;
    public decimal Price { get; private set; }

    private Product() { }

    public Product(string name, decimal price)
    {
        ValidateName(name);
        ValidatePrice(price);

        Name = name;
        Price = price;

    }

    public void Rename(string newName)
    {
        ValidateName(newName);
        Name = newName;
    }

    public void ChangePrice(decimal newPrice)
    {
        ValidatePrice(newPrice);
        Price= newPrice;
    }

    private static void  ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException("Product Name cannot be empty");
        }
    }

    private static void ValidatePrice(decimal price)
    {
        if (price <= 0)
        {
            throw new DomainException($"Invalid price {price}");
        }
    }
}
