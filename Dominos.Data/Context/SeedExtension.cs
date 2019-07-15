using Dominos.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominos.Data.Context
{
    public static class SeedExtension
    {
        public static void Seed(this EfContext context)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    if (context.Products.Any() || context.ProductTypes.Any())
                    {
                        return;
                    }
                    context.ProductTypes.AddRange(new List<ProductType> {
                        new ProductType
                        {
                            Name = "Pizza"
                        },
                        new ProductType
                        {
                            Name = "Side"
                        },
                        new ProductType
                        {
                            Name = "Drink"
                        }
                    });
                    context.SaveChanges();

                    context.Products.AddRange(new List<Product> {
                        new Product
                        {
                            ProductName = "Karışık Pizza",
                            Description = "Sucuk, Sosis, Misir, Mozarella Peyniri, Pizza Sos, Yesil Biber, Mantar",
                            Price = 55.99,
                            TypeId = context.ProductTypes.AsNoTracking().FirstOrDefault(x => x.Name == "Pizza").Id,
                            IsActive = true,
                            ImagePath = "https://dpe-cdn.azureedge.net/api/medium/ProductOsg/Global/_KARISIK/NULL/434x404/TR?v=b56705583d2694a668f14ec1de8f3d57-1563102600000"
                        },
                        new Product
                        {
                            ProductName = "Bolmalzemos",
                            Description = "Jambon, Pepperoni, Sucuk, Sosis, Misir, Mozarella Peyniri, Pizza Sos, Siyah Zeytin, Yesil",
                            Price = 55.99,
                            TypeId = context.ProductTypes.AsNoTracking().FirstOrDefault(x => x.Name == "Pizza").Id,
                            IsActive = true,
                            ImagePath = "https://dpe-cdn.azureedge.net/api/medium/ProductOsg/Global/_BMPIZ/NULL/434x404/TR?v=b56705583d2694a668f14ec1de8f3d57-1563102600000"
                        },
                        new Product
                        {
                            ProductName = "Tavuk Parçaları",
                            Description = "Marine edilmiş tavuk parçaları",
                            Price = 8.90,
                            TypeId = context.ProductTypes.AsNoTracking().FirstOrDefault(x => x.Name == "Side").Id,
                            IsActive = true,
                            ImagePath = "https://dpe-cdn.azureedge.net/api/medium/Product/Global/_100KICK/NULL/434x404/TR?v=b56705583d2694a668f14ec1de8f3d57-1563102720000"
                        },
                        new Product
                        {
                            ProductName = "Sufle",
                            Description = "Sıcacık, akışkan çikolatası ile tadına doyamayacağınız enfes sufle",
                            Price = 9.99,
                            TypeId = context.ProductTypes.AsNoTracking().FirstOrDefault(x => x.Name == "Side").Id,
                            IsActive = true,
                            ImagePath = "https://dpe-cdn.azureedge.net/api/medium/Product/Global/_SUFLE/NULL/434x404/TR?v=b56705583d2694a668f14ec1de8f3d57-1563102720000"
                        },
                        new Product
                        {
                            ProductName = "Kola",
                            Description = "Kutu Coca-Cola",
                            Price = 5.99,
                            TypeId = context.ProductTypes.AsNoTracking().FirstOrDefault(x => x.Name == "Drink").Id,
                            IsActive = true,
                            ImagePath = "https://dpe-cdn.azureedge.net/api/medium/Product/Global/D12CCOKE/NULL/434x404/TR?v=b56705583d2694a668f14ec1de8f3d57-1563102720000"
                        },
                        new Product
                        {
                            ProductName = "Ayran",
                            Description = "Sütaş Ayran",
                            Price = 4.99,
                            TypeId = context.ProductTypes.AsNoTracking().FirstOrDefault(x => x.Name == "Drink").Id,
                            IsActive = true,
                            ImagePath = "https://dpe-cdn.azureedge.net/api/medium/Product/Global/_300AYRAN/NULL/434x404/TR?v=b56705583d2694a668f14ec1de8f3d57-1563102720000"
                        },
                        new Product
                        {
                            ProductName = "Süperos",
                            Description = "Jambon, Sucuk, Sosis, Mozarella Peyniri, Pizza Sos, Siyah Zeytin, Domates, Kekik",
                            Price = 49.99,
                            TypeId = context.ProductTypes.AsNoTracking().FirstOrDefault(x=> x.Name == "Pizza").Id,
                            IsActive = true,
                            ImagePath = "https://dpe-cdn.azureedge.net/api/medium/ProductOsg/Global/DOPDOLU/NULL/434x404/TR?v=b56705583d2694a668f14ec1de8f3d57-1563195000000"
                        }
                    });
                    context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    var exception = ex;
                    transaction.Rollback();
                }
            }
        }
    }
}